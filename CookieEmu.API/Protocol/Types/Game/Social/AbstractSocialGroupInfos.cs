namespace CookieEmu.API.Protocol.Network.Types.Game.Social
{
    using CookieEmu.API.IO;

    public class AbstractSocialGroupInfos : NetworkType
    {
        public const ushort ProtocolId = 416;
        public override ushort TypeID => ProtocolId;

        public AbstractSocialGroupInfos() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
