﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeRequestOnMountStockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5986;
        public override ushort MessageID => ProtocolId;

        public ExchangeRequestOnMountStockMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
