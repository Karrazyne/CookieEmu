namespace CookieEmu.API.Protocol.Network.Types.Game.Friend
{
    using CookieEmu.API.IO;

    public class IgnoredInformations : AbstractContactInformations
    {
        public new const ushort ProtocolId = 106;
        public override ushort TypeID => ProtocolId;

        public IgnoredInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
