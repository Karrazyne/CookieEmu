namespace CookieEmu.API.Protocol.Network.Messages.Game.Character.Choice
{
    using CookieEmu.API.IO;

    public class CharactersListErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5545;
        public override ushort MessageID => ProtocolId;

        public CharactersListErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
