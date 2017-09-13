namespace CookieEmu.API.Protocol.Network.Messages.Connection.Register
{
    using CookieEmu.API.IO;

    public class NicknameAcceptedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5641;
        public override ushort MessageID => ProtocolId;

        public NicknameAcceptedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
