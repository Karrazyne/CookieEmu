namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using CookieEmu.API.IO;

    public class MapRunningFightListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5742;
        public override ushort MessageID => ProtocolId;

        public MapRunningFightListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
