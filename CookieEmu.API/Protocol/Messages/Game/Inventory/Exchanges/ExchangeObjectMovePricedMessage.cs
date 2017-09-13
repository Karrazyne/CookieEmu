namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
    {
        public new const ushort ProtocolId = 5514;
        public override ushort MessageID => ProtocolId;
        public ulong Price { get; set; }

        public ExchangeObjectMovePricedMessage(ulong price)
        {
            Price = price;
        }

        public ExchangeObjectMovePricedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Price = reader.ReadVarUhLong();
        }

    }
}
