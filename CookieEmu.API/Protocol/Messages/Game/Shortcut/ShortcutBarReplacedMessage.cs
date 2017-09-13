﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Shortcut
{
    using Types.Game.Shortcut;
    using CookieEmu.API.IO;

    public class ShortcutBarReplacedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6706;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public Shortcut Shortcut { get; set; }

        public ShortcutBarReplacedMessage(byte barType, Shortcut shortcut)
        {
            BarType = barType;
            Shortcut = shortcut;
        }

        public ShortcutBarReplacedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteUShort(Shortcut.TypeID);
            Shortcut.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            Shortcut = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadUShort());
            Shortcut.Deserialize(reader);
        }

    }
}
