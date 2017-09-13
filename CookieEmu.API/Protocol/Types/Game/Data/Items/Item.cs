namespace CookieEmu.API.Protocol.Network.Types.Game.Data.Items
{
    using CookieEmu.API.IO;

    public class Item : NetworkType
    {
        public const ushort ProtocolId = 7;
        public override ushort TypeID => ProtocolId;

        public Item() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
