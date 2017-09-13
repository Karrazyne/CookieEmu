namespace CookieEmu.API.Protocol.Network.Types.Game.Character
{
    using CookieEmu.API.IO;

    public class AbstractCharacterInformation : NetworkType
    {
        public const ushort ProtocolId = 400;
        public override ushort TypeID => ProtocolId;
        public ulong ObjectId { get; set; }

        public AbstractCharacterInformation(ulong objectId)
        {
            ObjectId = objectId;
        }

        public AbstractCharacterInformation() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhLong();
        }

    }
}
