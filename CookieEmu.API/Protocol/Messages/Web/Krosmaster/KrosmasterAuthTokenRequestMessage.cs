namespace CookieEmu.API.Protocol.Network.Messages.Web.Krosmaster
{
    using CookieEmu.API.IO;

    public class KrosmasterAuthTokenRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6346;
        public override ushort MessageID => ProtocolId;

        public KrosmasterAuthTokenRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
