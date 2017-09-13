namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Fight
{
    using CookieEmu.API.IO;

    public class GameFightPlacementSwapPositionsErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6548;
        public override ushort MessageID => ProtocolId;

        public GameFightPlacementSwapPositionsErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
