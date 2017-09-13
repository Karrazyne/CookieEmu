namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using CookieEmu.API.IO;

    public class EditHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6626;
        public override ushort MessageID => ProtocolId;

        public EditHavenBagRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
