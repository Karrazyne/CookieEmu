namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeObjectTransfertAllFromInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6184;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectTransfertAllFromInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
