namespace CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using CookieEmu.API.IO;

    public class TreasureHuntStep : NetworkType
    {
        public const ushort ProtocolId = 463;
        public override ushort TypeID => ProtocolId;

        public TreasureHuntStep() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
