namespace CookieEmu.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using CookieEmu.API.IO;

    public class TaxCollectorErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5634;
        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

        public TaxCollectorErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public TaxCollectorErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }

    }
}
