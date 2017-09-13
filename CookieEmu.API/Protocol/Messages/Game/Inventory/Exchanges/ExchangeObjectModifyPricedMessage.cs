namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
    {
        public new const ushort ProtocolId = 6238;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectModifyPricedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
