namespace CookieEmu.API.Protocol.Network.Types.Game.Approach
{
    using CookieEmu.API.IO;

    public class ServerSessionConstantString : ServerSessionConstant
    {
        public new const ushort ProtocolId = 436;
        public override ushort TypeID => ProtocolId;
        public string Value { get; set; }

        public ServerSessionConstantString(string value)
        {
            Value = value;
        }

        public ServerSessionConstantString() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadUTF();
        }

    }
}
