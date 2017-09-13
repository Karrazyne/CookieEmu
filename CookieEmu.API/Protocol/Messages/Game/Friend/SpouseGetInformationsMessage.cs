namespace CookieEmu.API.Protocol.Network.Messages.Game.Friend
{
    using CookieEmu.API.IO;

    public class SpouseGetInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6355;
        public override ushort MessageID => ProtocolId;

        public SpouseGetInformationsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
