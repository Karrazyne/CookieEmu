﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Dialog
{
    using CookieEmu.API.IO;

    public class LeaveDialogRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5501;
        public override ushort MessageID => ProtocolId;

        public LeaveDialogRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
