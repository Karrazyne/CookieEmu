﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using CookieEmu.API.IO;

    public class ExchangeMountStableErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5981;
        public override ushort MessageID => ProtocolId;

        public ExchangeMountStableErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
