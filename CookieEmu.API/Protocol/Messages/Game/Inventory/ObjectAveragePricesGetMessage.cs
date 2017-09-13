﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory
{
    using CookieEmu.API.IO;

    public class ObjectAveragePricesGetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6334;
        public override ushort MessageID => ProtocolId;

        public ObjectAveragePricesGetMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
