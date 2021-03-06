﻿namespace CookieEmu.API.Protocol.Network.Messages.Updater.Parts
{
    using CookieEmu.API.IO;

    public class GetPartsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1501;
        public override ushort MessageID => ProtocolId;

        public GetPartsListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
