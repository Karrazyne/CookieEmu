﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Friend
{
    using CookieEmu.API.IO;

    public class FriendSpouseJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5604;
        public override ushort MessageID => ProtocolId;

        public FriendSpouseJoinRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
