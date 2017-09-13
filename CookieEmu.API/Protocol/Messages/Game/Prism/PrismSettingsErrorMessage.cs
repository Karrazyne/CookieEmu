﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Prism
{
    using CookieEmu.API.IO;

    public class PrismSettingsErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6442;
        public override ushort MessageID => ProtocolId;

        public PrismSettingsErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
