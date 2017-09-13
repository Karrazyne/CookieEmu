namespace CookieEmu.API.Protocol.Network.Messages.Updater.Parts
{
    using CookieEmu.API.IO;

    public class DownloadGetCurrentSpeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1510;
        public override ushort MessageID => ProtocolId;

        public DownloadGetCurrentSpeedRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
