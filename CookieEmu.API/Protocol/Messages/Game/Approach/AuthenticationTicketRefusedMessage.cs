﻿namespace CookieEmu.API.Protocol.Network.Messages.Game.Approach
{
    using CookieEmu.API.IO;

    public class AuthenticationTicketRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 112;
        public override ushort MessageID => ProtocolId;

        public AuthenticationTicketRefusedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
