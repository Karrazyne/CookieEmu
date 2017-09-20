using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Game.Friend;
using CookieEmu.API.Protocol.Network.Types.Game.Friend;
using CookieEmu.Game.Network;

namespace CookieEmu.Game.Engine.Handler.Social
{
    public class SocialHandler
    {
        [MessageHandler(typeof(FriendsGetListMessage))]
        public static void HandleFriendsGetListMessage(FriendsGetListMessage message, Client client)
        {
            client.SendAsync(new FriendsListMessage(new List<FriendInformations>()));
        }

        [MessageHandler(typeof(IgnoredGetListMessage))]
        public static void HandleIgnoredGetListMessage(IgnoredGetListMessage message, Client client)
        {
            client.SendAsync(new IgnoredListMessage(new List<IgnoredInformations>()));
        }

        [MessageHandler(typeof(SpouseGetInformationsMessage))]
        public static void HandleSpouseGetInformationsMessage(SpouseGetInformationsMessage message, Client client)
        {
            client.SendAsync(new BasicNoOperationMessage());
        }
    }
}
