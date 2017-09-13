namespace CookieEmu.API.Protocol.Network.Types.Common.Basic
{
    using CookieEmu.API.IO;

    public class StatisticDataBoolean : StatisticData
    {
        public new const ushort ProtocolId = 482;
        public override ushort TypeID => ProtocolId;
        public bool Value { get; set; }

        public StatisticDataBoolean(bool value)
        {
            Value = value;
        }

        public StatisticDataBoolean() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadBoolean();
        }

    }
}
