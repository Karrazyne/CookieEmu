namespace CookieEmu.API.Protocol.Network.Messages.Game.Approach
{
    using CookieEmu.API.IO;

    public class HelloGameMessage : NetworkMessage
    {
        public const ushort ProtocolId = 101;
        public override ushort MessageID => ProtocolId;

        public HelloGameMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
