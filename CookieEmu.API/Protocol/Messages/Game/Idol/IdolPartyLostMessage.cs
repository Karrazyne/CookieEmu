namespace CookieEmu.API.Protocol.Network.Messages.Game.Idol
{
    using CookieEmu.API.IO;

    public class IdolPartyLostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6580;
        public override ushort MessageID => ProtocolId;
        public ushort IdolId { get; set; }

        public IdolPartyLostMessage(ushort idolId)
        {
            IdolId = idolId;
        }

        public IdolPartyLostMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolId = reader.ReadVarUhShort();
        }

    }
}
