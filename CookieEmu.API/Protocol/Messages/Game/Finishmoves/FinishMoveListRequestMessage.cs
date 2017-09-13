namespace CookieEmu.API.Protocol.Network.Messages.Game.Finishmoves
{
    using CookieEmu.API.IO;

    public class FinishMoveListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6702;
        public override ushort MessageID => ProtocolId;

        public FinishMoveListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
