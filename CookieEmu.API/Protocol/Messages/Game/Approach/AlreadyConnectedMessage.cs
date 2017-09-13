﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Approach
{
    using CookieEmu.API.IO;

    public class AlreadyConnectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 109;
        public override ushort MessageID => ProtocolId;

        public AlreadyConnectedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
