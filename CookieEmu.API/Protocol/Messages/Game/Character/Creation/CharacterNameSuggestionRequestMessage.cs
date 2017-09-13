namespace CookieEmu.API.Protocol.Network.Messages.Game.Character.Creation
{
    using CookieEmu.API.IO;

    public class CharacterNameSuggestionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 162;
        public override ushort MessageID => ProtocolId;

        public CharacterNameSuggestionRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
