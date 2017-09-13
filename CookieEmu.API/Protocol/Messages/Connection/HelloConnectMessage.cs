namespace CookieEmu.API.Protocol.Network.Messages.Connection
{
    using System.Collections.Generic;
    using CookieEmu.API.IO;

    public class HelloConnectMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3;
        public override ushort MessageID => ProtocolId;
        public string Salt { get; set; }
        public sbyte[] Key { get; set; }

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            Salt = salt;
            Key = key;
        }

        public HelloConnectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt(Key.Length);
            var numArray = Key;
            foreach (var t in numArray)
            {
                writer.WriteSByte(t);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Salt = reader.ReadUTF();
            var keyCount = reader.ReadVarInt();
            Key = new sbyte[keyCount];
            for (var keyIndex = 0; keyIndex < keyCount; keyIndex++)
            {
                Key[keyIndex] = reader.ReadSByte();
            }
        }

    }
}
