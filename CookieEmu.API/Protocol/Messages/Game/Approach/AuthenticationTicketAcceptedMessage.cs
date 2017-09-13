namespace CookieEmu.API.Protocol.Network.Messages.Game.Approach
{
    using CookieEmu.API.IO;

    public class AuthenticationTicketAcceptedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 111;
        public override ushort MessageID => ProtocolId;

        public AuthenticationTicketAcceptedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
