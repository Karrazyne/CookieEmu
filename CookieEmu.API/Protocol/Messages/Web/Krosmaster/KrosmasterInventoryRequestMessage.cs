﻿namespace CookieEmu.API.Protocol.Network.Messages.Web.Krosmaster
{
    using CookieEmu.API.IO;

    public class KrosmasterInventoryRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6344;
        public override ushort MessageID => ProtocolId;

        public KrosmasterInventoryRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
