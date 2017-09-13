namespace CookieEmu.API.Protocol.Network.Messages.Game.Guild
{
    using CookieEmu.API.IO;

    public class GuildFactsErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6424;
        public override ushort MessageID => ProtocolId;
        public uint GuildId { get; set; }

        public GuildFactsErrorMessage(uint guildId)
        {
            GuildId = guildId;
        }

        public GuildFactsErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUhInt();
        }

    }
}
