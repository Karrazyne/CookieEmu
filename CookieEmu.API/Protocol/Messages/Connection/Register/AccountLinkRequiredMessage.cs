namespace CookieEmu.API.Protocol.Network.Messages.Connection.Register
{
    using CookieEmu.API.IO;

    public class AccountLinkRequiredMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6607;
        public override ushort MessageID => ProtocolId;

        public AccountLinkRequiredMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
