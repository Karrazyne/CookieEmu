using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CookieEmu.API.Extensions;
using CookieEmu.API.IO;
using CookieEmu.API.Protocol;
using CookieEmu.API.Protocol.Network.Messages.Connection;
using CookieEmu.API.Protocol.Network.Messages.Handshake;
using CookieEmu.Auth.Engine.Types;
using CookieEmu.Common.Console;

namespace CookieEmu.Auth.Network
{
    public class Client
    {
        public Socket ClientSocket { get; set; }
        public string Ticket { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public byte[] AesKey { get; set; }

        private MessageInformations MessageParser { get; set; }

        private readonly Random _random = new Random();

        public sbyte[] RsaKey { get; set; }

        public Client(Socket s)
        {
            ClientSocket = s;
            Ip = ((IPEndPoint) ClientSocket.RemoteEndPoint).Address.ToString();
            Port = ((IPEndPoint)ClientSocket.RemoteEndPoint).Port.ToString();

            Ticket = _random.RandomString(32);

            MessageParser = new MessageInformations(this);

            RsaKey = GenerateRsaPublicKey();

            Logger.Write($"Client joined on {Ip}:{Port}");

            StartReceive();

            SendAsync(new ProtocolRequired(1781, 1781));
            SendAsync(new HelloConnectMessage(Ticket, RsaKey));
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

        public void Disconnect()
        {
            AuthServer.Clients.Remove(this);
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

        static sbyte[] GenerateRsaPublicKey()
        {
            const string publicKeyBase64 = "Vphs/8DzshWGwQ8ydffFVi8YtPqFGOfd3KWydc8ZdUFXhg8Npols4zwIT++s8z+/0Jqn6OI5i68uXgldDGB6zUX5a5RP9r7qgLFh4jYyywtkHeDv3CcPk2vekZkY9eaL+0AO50DUMsW6tyghFebWFyhkEck9CW7oqWVap99uRe/qXwk39LdrkNeFADdAPkO4infbVDQTy8EtozzBro5b9TuZSKiBUvfgUxR3kJ1u66N8IV5dB0guKmord1ZOYzhMokOMezkZ3ISBPltysSLwLFmYdpLfm/TvHaWcsfSmZjlWvtnXWowTssgqkmryVuVYrkB9ezcGIjXuQ7AYbnXXVIQb68VH02DfmPE15cBzqrUskcScH+lwIbuV0Yiy1XGXr4D0HERr7q5h87U5HLkedl8=";
            
            return Convert.FromBase64String(publicKeyBase64).Select(entry => (sbyte)entry).ToArray();
        }
    }
}
