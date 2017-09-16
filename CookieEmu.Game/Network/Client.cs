using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CookieEmu.API.Extensions;
using CookieEmu.API.IO;
using CookieEmu.API.Protocol;
using CookieEmu.API.Protocol.Network.Messages.Game.Approach;
using CookieEmu.API.Protocol.Network.Messages.Handshake;
using CookieEmu.Common.Console;
using CookieEmu.Game.Engine.Types;
using CookieEmu.Game.Game.Maps;
using CookieEmu.Game.SQL.Account;
using CookieEmu.Game.SQL.Character;

namespace CookieEmu.Game.Network
{
    public class Client
    {
        public Socket ClientSocket { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }

        public Account Account { get; set; }
        public Character Character { get; set; }
        public Map CurrentMap { get; set; }

        private MessageInformations MessageParser { get; set; }

        private readonly Random _random = new Random();

        public Client(Socket s)
        {
            ClientSocket = s;
            Ip = ((IPEndPoint) ClientSocket.RemoteEndPoint).Address.ToString();
            Port = ((IPEndPoint)ClientSocket.RemoteEndPoint).Port.ToString();

            MessageParser = new MessageInformations(this);

            Logger.Write($"Client joined on {Ip}:{Port}");

            StartReceive();

            SendAsync(new ProtocolRequired(1781, 1781));
            SendAsync(new HelloGameMessage());
        }

        private void StartReceive()
        {
            Task.Factory.StartNew(async () =>
            {
                for (;;)
                {
                    var buffer = new byte[8192];
                    var bytesToRead = await ClientSocket.ReceiveTask(buffer, 0, buffer.Length);
                    if (bytesToRead > 0)
                    {
                        var packet = new byte[bytesToRead];
                        Array.Copy(buffer, packet, packet.Length);

                        MessageParser.ParseBuffer(packet);
                    }
                    else
                    {
                        Disconnect();
                        break;
                    }
                }
            });
        }

        public void Log(string content) => Logger.Write(content);

        public async void Disconnect()
        {
            await Task.Delay(1000);
            GameServer.Clients.Remove(this);
            Logger.Write($"Client {Ip}:{Port} leave...");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        public async void SendAsync(NetworkMessage message)
        {
                using (var writer = new BigEndianWriter())
                {
                    message.Pack(writer);
                    await ClientSocket.SendTask(writer.Data, 0, writer.Data.Length);
                    Log($"[SND] ({message.MessageID}) {message}");
                }
        }
    }
}
