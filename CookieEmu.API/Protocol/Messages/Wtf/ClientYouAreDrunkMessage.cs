namespace CookieEmu.API.Protocol.Network.Messages.Wtf
{
    using Messages.Debug;
    using CookieEmu.API.IO;

    public class ClientYouAreDrunkMessage : DebugInClientMessage
    {
        public new const ushort ProtocolId = 6594;
        public override ushort MessageID => ProtocolId;

        public ClientYouAreDrunkMessage() { }

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
