using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CookieEmu.API.IO;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Messages.Custom;
using CookieEmu.API.Protocol.Network.Messages.Connection;
using CookieEmu.API.Protocol.Network.Messages.Connection.Register;
using CookieEmu.API.Protocol.Network.Messages.Security;
using CookieEmu.API.Protocol.Network.Types.Connection;
using CookieEmu.Auth.Network;
using CookieEmu.Auth.SQL;
using CookieEmu.Common;
using CookieEmu.Common.Console;

namespace CookieEmu.Auth.Engine.Handler
{
    public class LoginHandler
    {

        [MessageHandler(typeof (IdentificationMessage))]
        public static void HandleIdentificationMessage(IdentificationMessage message, Client client)
        {
            if (message.Version.ToString() != "2.43.5.179283633.0.0.1.1")
            {
                var messageToSend =
                    new IdentificationFailedForBadVersionMessage(
                        new API.Protocol.Network.Types.Version.Version(2, 43, 5, 179283633, 0, 0));
                client.SendAsync(messageToSend);
                return;
            }
                client.SendAsync(new RawDataMessage(File.ReadAllBytes("./AuthPatch.swf")));
        }

        [MessageHandler(typeof(ClearIdentificationMessage))]
        public static void HandleClearIdentificationMessage(ClearIdentificationMessage message, Client client)
        {
            Account account;
            if (AccountManager.ReturnAccount(message.Username, message.Password, out account))
            {
                client.Account = account;
                if (client.Account.Nickname == "AChanger")
                {
                    client.SendAsync(new NicknameRegistrationMessage());
                    return;
                }
                SendIdentificationSuccessMessage(client);
                SendServerListMessage(client);
                return;
            }
            client.SendAsync(new IdentificationFailedMessage((byte)IdentificationFailureReasonEnum.WRONG_CREDENTIALS));
        }

        [MessageHandler(typeof (ServerSelectionMessage))]
        public static void HandleServerSelectionMessage(ServerSelectionMessage message, Client client)
        {
            SendSelectedServerData(message, client);
        }

        [MessageHandler(typeof(NicknameChoiceRequestMessage))]
        public static void HandleNicknameChoiceRequestMessage(NicknameChoiceRequestMessage message, Client client)
        {
            if (CheckNickName(message.Nickname) || message.Nickname == "AChanger")
            {
                client.SendAsync(new NicknameRefusedMessage((byte)NicknameErrorEnum.INVALID_NICK));
                return;
            }
            if (AccountManager.NicknameAlreadyExist(message.Nickname))
            {
                client.SendAsync(new NicknameRefusedMessage((byte)NicknameErrorEnum.ALREADY_USED));
                return;
            }
            if (message.Nickname == client.Account.Login)
            {
                client.SendAsync(new NicknameRefusedMessage((byte)NicknameErrorEnum.SAME_AS_LOGIN));
                return;
            }

            client.Account.Nickname = message.Nickname;
            client.Account.UpdateNickname();
            client.SendAsync(new NicknameAcceptedMessage());
            SendIdentificationSuccessMessage(client);
            SendServerListMessage(client);
        }

        private static void SendSelectedServerData(ServerSelectionMessage message, Client client)
        {
            //TODO
                client.SendAsync(new SelectedServerDataMessage(message.ServerId, "127.0.0.1", 5678, true, Encoding.ASCII.GetBytes(client.Ticket).Select(x => (sbyte)x).ToList()));

            client.Account.Ticket = client.Ticket;
            client.Account.UpdateTicket();

            client.Disconnect();
        }

        private static void SendServerListMessage(Client client)
        {
            var characterCounts = CharacterManager.ReturnCharacters(client.Account.Id);
            var messageToSend = new ServersListMessage(new List<GameServerInformations>
            {
                new GameServerInformations(36, 1, (byte) ServerStatusEnum.ONLINE, 1, true, (byte) characterCounts.Count, 5,
                    Functions.ReturnUnixTimeStamp(DateTime.Now))
            }, 0, true);
            client.SendAsync(messageToSend);

        }

        private static void SendIdentificationSuccessMessage(Client client)
        {
            client.SendAsync(new IdentificationSuccessMessage(true, false, client.Account.Login, client.Account.Nickname, 1, 1, client.Account.SecretQuestion, 45646468, 5645645646, 56468785, 0));
        }

        private static bool CheckNickName(string nickname) =>
            Regex.IsMatch(nickname, "^[a-zA-Z\\-] {3,29}$", RegexOptions.Compiled);
    }
}
