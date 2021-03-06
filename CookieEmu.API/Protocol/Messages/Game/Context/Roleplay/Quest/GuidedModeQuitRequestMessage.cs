﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using CookieEmu.API.IO;

    public class GuidedModeQuitRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6092;
        public override ushort MessageID => ProtocolId;

        public GuidedModeQuitRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
