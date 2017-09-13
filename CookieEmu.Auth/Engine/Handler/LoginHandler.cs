using System;
using System.Collections.Generic;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Messages.Connection;
using CookieEmu.API.Protocol.Network.Types.Connection;
using CookieEmu.Auth.Network;
using CookieEmu.Common;

namespace CookieEmu.Auth.Engine.Handler
{
    public class LoginHandler
    {
        [MessageHandler(typeof (IdentificationMessage))]
        public static void HandleIdentificationMessage(IdentificationMessage message, Client client)
        {
            //TODO
            // Gérer le login ^_^
            if (message.Version.ToString() != "2.43.3.285950.0.0.1.1")
            {
                var messageToSend =
                    new IdentificationFailedForBadVersionMessage(
                        new API.Protocol.Network.Types.Version.Version(2, 43, 3, 285950, 0, 0));
                client.SendAsync(messageToSend);
                return;
            }
            SendIdentificationSuccessMessage(client);
            SendServerListMessage(client);
        }

        [MessageHandler(typeof (ServerSelectionMessage))]
        public static void HandleServerSelectionMessage(ServerSelectionMessage message, Client client)
        {
            SendSelectedServerData(message, client);
        }

        private static void SendSelectedServerData(ServerSelectionMessage message, Client client)
        {
            //TODO
        }

        private static void SendServerListMessage(Client client)
        {
            var messageToSend = new ServersListMessage(new List<GameServerInformations>
            {
                new GameServerInformations(36, 1, (byte) ServerStatusEnum.ONLINE, 1, true, 0, 5,
                    Functions.ReturnUnixTimeStamp(DateTime.Now))
            }, 0, true);
            client.SendAsync(messageToSend);

        }

        private static void SendIdentificationSuccessMessage(Client client)
        {
            client.SendAsync(new IdentificationSuccessMessage(true, false, "Admin", "Admin", 1, 1, "lol", 45646468, 5645645646, 56468785, 0));
        }
    }
}
