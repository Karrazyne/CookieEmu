﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Alliance
{
    using CookieEmu.API.IO;

    public class AllianceLeftMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6398;
        public override ushort MessageID => ProtocolId;

        public AllianceLeftMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
