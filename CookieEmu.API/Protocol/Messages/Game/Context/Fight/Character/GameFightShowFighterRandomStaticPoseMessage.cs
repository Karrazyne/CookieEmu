namespace CookieEmu.API.Protocol.Network.Messages.Game.Context.Fight.Character
{
    using Types.Game.Context.Fight;
    using CookieEmu.API.IO;

    public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
    {
        public new const ushort ProtocolId = 6218;
        public override ushort MessageID => ProtocolId;

        public GameFightShowFighterRandomStaticPoseMessage() { }

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
