﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Prism
{
    using CookieEmu.API.IO;

    public class PrismModuleExchangeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6531;
        public override ushort MessageID => ProtocolId;

        public PrismModuleExchangeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
