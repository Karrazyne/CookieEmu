namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Mount
{
    using CookieEmu.API.IO;

    public class MountToggleRidingRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5976;
        public override ushort MessageID => ProtocolId;

        public MountToggleRidingRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
