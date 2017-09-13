namespace CookieEmu.API.Protocol.Network.Types.Game.Guild.Tax
{
    using CookieEmu.API.IO;

    public class TaxCollectorComplementaryInformations : NetworkType
    {
        public const ushort ProtocolId = 448;
        public override ushort TypeID => ProtocolId;

        public TaxCollectorComplementaryInformations() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
