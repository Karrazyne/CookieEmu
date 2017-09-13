namespace CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using CookieEmu.API.IO;

    public class HumanOption : NetworkType
    {
        public const ushort ProtocolId = 406;
        public override ushort TypeID => ProtocolId;

        public HumanOption() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
