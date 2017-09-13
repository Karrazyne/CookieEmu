﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    using CookieEmu.API.IO;

    public class LockableChangeCodeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5666;
        public override ushort MessageID => ProtocolId;
        public string Code { get; set; }

        public LockableChangeCodeMessage(string code)
        {
            Code = code;
        }

        public LockableChangeCodeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            Code = reader.ReadUTF();
        }

    }
}
