﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Messages.Game.Inventory;
    using CookieEmu.API.IO;

    public class InventoryPresetSaveResultMessage : AbstractPresetSaveResultMessage
    {
        public new const ushort ProtocolId = 6170;
        public override ushort MessageID => ProtocolId;

        public InventoryPresetSaveResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
