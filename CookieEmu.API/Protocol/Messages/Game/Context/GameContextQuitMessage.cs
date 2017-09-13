﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Context
{
    using CookieEmu.API.IO;

    public class GameContextQuitMessage : NetworkMessage
    {
        public const ushort ProtocolId = 255;
        public override ushort MessageID => ProtocolId;

        public GameContextQuitMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
