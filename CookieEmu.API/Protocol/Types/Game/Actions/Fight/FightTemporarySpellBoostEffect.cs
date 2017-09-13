namespace CookieEmu.API.Protocol.Network.Types.Game.Actions.Fight
{
    using CookieEmu.API.IO;

    public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 207;
        public override ushort TypeID => ProtocolId;
        public ushort BoostedSpellId { get; set; }

        public FightTemporarySpellBoostEffect(ushort boostedSpellId)
        {
            BoostedSpellId = boostedSpellId;
        }

        public FightTemporarySpellBoostEffect() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(BoostedSpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BoostedSpellId = reader.ReadVarUhShort();
        }

    }
}
