﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeStartAsVendorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5775;
        public override ushort MessageID => ProtocolId;

        public ExchangeStartAsVendorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
