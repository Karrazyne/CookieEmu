namespace CookieEmu.API.Protocol.Network.Messages.Game.Context
{
    using CookieEmu.API.IO;

    public class GameMapMovementConfirmMessage : NetworkMessage
    {
        public const ushort ProtocolId = 952;
        public override ushort MessageID => ProtocolId;

        public GameMapMovementConfirmMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
