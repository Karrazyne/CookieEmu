﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using CookieEmu.API.IO;

    public class NpcGenericActionFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5900;
        public override ushort MessageID => ProtocolId;

        public NpcGenericActionFailureMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
