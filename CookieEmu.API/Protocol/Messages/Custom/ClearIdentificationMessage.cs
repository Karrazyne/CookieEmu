using CookieEmu.API.IO;

namespace CookieEmu.API.Protocol.Messages.Custom
{
    public class ClearIdentificationMessage : NetworkMessage
    {
        public override ushort MessageID => ProtocolId;
        public const ushort ProtocolId = 888;

        public bool AutoConnect { get; set; }
        public string Lang { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public short ServerId { get; set; }
        public string ServerIp { get; set; }
        public string HardwareId { get; set; }

        public override void Serialize(IDataWriter writer)
        {

        }

        public override void Deserialize(IDataReader reader)
        {
            var loc2 = reader.ReadByte();
            AutoConnect = BooleanByteWrapper.GetFlag(loc2, 0);
            Lang = reader.ReadUTF();
            Username = reader.ReadUTF();
            Password = reader.ReadUTF();
            ServerId = reader.ReadShort();
            ServerIp = reader.ReadUTF();
            HardwareId = reader.ReadUTF();
        }
    }
}
