﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeShowVendorTaxMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5783;
        public override ushort MessageID => ProtocolId;

        public ExchangeShowVendorTaxMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
