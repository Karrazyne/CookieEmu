namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Document
{
    using CookieEmu.API.IO;

    public class DocumentReadingBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5675;
        public override ushort MessageID => ProtocolId;
        public ushort DocumentId { get; set; }

        public DocumentReadingBeginMessage(ushort documentId)
        {
            DocumentId = documentId;
        }

        public DocumentReadingBeginMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DocumentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DocumentId = reader.ReadVarUhShort();
        }

    }
}
