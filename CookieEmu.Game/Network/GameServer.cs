using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CookieEmu.API.Extensions;
using CookieEmu.Common.Console;

namespace CookieEmu.Game.Network
{
    public class GameServer
    {
        
        private static Socket AuthSocket { get; set; }

        public static List<Client> Clients = new List<Client>();

        public static void Start()
        {
            AuthSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            AuthSocket.Bind(new IPEndPoint(IPAddress.Any, 5678));
            AuthSocket.Listen(100);
            StartAccept();
        }

        private static void StartAccept()
        {
            Task.Factory.StartNew(async () =>
            {
                Logger.Write("GameServer starting, waiting for connection...");
                for (;;)
                    Clients.Add(new Client(await AuthSocket.AcceptTask()));
            });
        }
    }
}
