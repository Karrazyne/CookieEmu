﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Character.Choice
{
    using CookieEmu.API.IO;

    public class CharacterSelectedForceReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6072;
        public override ushort MessageID => ProtocolId;

        public CharacterSelectedForceReadyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
