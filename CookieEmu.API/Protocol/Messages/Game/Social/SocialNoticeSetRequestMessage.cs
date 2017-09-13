namespace CookieEmu.API.Protocol.Network.Messages.Game.Social
{
    using CookieEmu.API.IO;

    public class SocialNoticeSetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6686;
        public override ushort MessageID => ProtocolId;

        public SocialNoticeSetRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
