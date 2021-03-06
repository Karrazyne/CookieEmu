﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeRequestOnShopStockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5753;
        public override ushort MessageID => ProtocolId;

        public ExchangeRequestOnShopStockMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
