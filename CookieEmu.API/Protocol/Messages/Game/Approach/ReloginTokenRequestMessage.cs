namespace CookieEmu.API.Protocol.Network.Messages.Game.Approach
{
    using CookieEmu.API.IO;

    public class ReloginTokenRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6540;
        public override ushort MessageID => ProtocolId;

        public ReloginTokenRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
