using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Messages.Custom;
using CookieEmu.API.Protocol.Network.Messages.Authorized;
using CookieEmu.API.Protocol.Network.Messages.Game.Approach;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Secure;
using CookieEmu.API.Protocol.Network.Messages.Security;
using CookieEmu.API.Protocol.Network.Types.Game.Approach;
using CookieEmu.Common;
using CookieEmu.Game.Engine.Manager;
using CookieEmu.Game.Network;
using CookieEmu.Game.SQL;
using CookieEmu.Game.SQL.Account;

namespace CookieEmu.Game.Engine.Handler.Approach
{
    public class ApproachHandler
    {
        [MessageHandler(typeof(AuthenticationTicketMessage))]
        public static void HandleAuthenticationTicketMessage(AuthenticationTicketMessage message, Client client)
        {
            var ticketSplitted = message.Ticket.Split(',');
            message.Ticket = Encoding.ASCII.GetString(ticketSplitted.Select(x => (byte) (int.Parse(x))).ToArray());

            if (AccountManager.ReturnAccountWithTicket(message.Ticket, out Account account))
            {
                client.Account = account;
                client.Account.Characters = CharacterManager.ReturnCharacters(client.Account.Id);
                SendMessages(client);
            }
            else
            {
                client.SendAsync(new AuthenticationTicketRefusedMessage());
            }
        }

        private static void SendMessages(Client client)
        {
            var avaibleBreeds = new List<PlayableBreedEnum>()
            {
                PlayableBreedEnum.Feca,
                PlayableBreedEnum.Osamodas,
                PlayableBreedEnum.Enutrof,
                PlayableBreedEnum.Sram,
                PlayableBreedEnum.Xelor,
                PlayableBreedEnum.Ecaflip,
                PlayableBreedEnum.Eniripsa,
                PlayableBreedEnum.Iop,
                PlayableBreedEnum.Cra,
                PlayableBreedEnum.Sadida,
                PlayableBreedEnum.Sacrieur,
                PlayableBreedEnum.Pandawa,
                PlayableBreedEnum.Roublard,
                PlayableBreedEnum.Zobal,
                PlayableBreedEnum.Steamer,
                PlayableBreedEnum.Eliotrope,
                PlayableBreedEnum.Huppermage,
                PlayableBreedEnum.Ouginak
            };

            var flags = (uint) avaibleBreeds.Aggregate(0,
                (current, breedEnum) => current | 1 << breedEnum - PlayableBreedEnum.Feca);

            client.SendAsync(new AuthenticationTicketAcceptedMessage());
            client.SendAsync(new BasicTimeMessage(Functions.ReturnUnixTimeStamp(DateTime.Now), 60));
            client.SendAsync(new ServerSettingsMessage("fr", 0, 0, 30));
            client.SendAsync(new ServerOptionalFeaturesMessage(new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }));
            client.SendAsync(new ServerSessionConstantsMessage(new List<ServerSessionConstant>
            {
                new ServerSessionConstant(1)
            }));

            client.SendAsync(new AccountCapabilitiesMessage(true, true, client.Account.Id, flags, flags, 5));
            client.SendAsync(new TrustStatusMessage(true, true));
        }

        [MessageHandler(typeof(AdminQuietCommandMessage))]
        public static void HandleAdminQuietCommandMessage(AdminQuietCommandMessage message, Client client)
        {
            var dest = message.Content.Replace("moveto","").Trim();
            int mapId;
            if (int.TryParse(dest, out mapId))
            {
                MapManager.ChangeMap(client, mapId);
            }
            else
                Console.WriteLine(message.Content);
        }
    }
}
