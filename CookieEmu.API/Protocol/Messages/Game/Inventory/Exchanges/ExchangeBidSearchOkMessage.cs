﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeBidSearchOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5802;
        public override ushort MessageID => ProtocolId;

        public ExchangeBidSearchOkMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
