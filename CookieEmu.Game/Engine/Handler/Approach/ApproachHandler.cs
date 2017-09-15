using System.IO;
using CookieEmu.API.Protocol.Messages.Custom;
using CookieEmu.API.Protocol.Network.Messages.Game.Approach;
using CookieEmu.API.Protocol.Network.Messages.Security;
using CookieEmu.Game.Network;

namespace CookieEmu.Game.Engine.Handler.Approach
{
    public class ApproachHandler
    {
        [MessageHandler(typeof(AuthenticationTicketMessage))]
        public static void HandleAuthenticationTicketMessage(AuthenticationTicketMessage message, Client client)
        {
            client.SendAsync(new RawDataMessage(File.ReadAllBytes("./AuthPatch.swf")));
        }

        [MessageHandler(typeof(ClearIdentificationMessage))]
        public static void HandleClearIdentificationMessage(ClearIdentificationMessage message, Client client)
        {
            client.SendAsync(new AuthenticationTicketAcceptedMessage());
        }
    }
}
