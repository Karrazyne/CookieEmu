namespace CookieEmu.API.Protocol.Network.Types.Game.Character.Restriction
{
    using CookieEmu.API.IO;

    public class ActorRestrictionsInformations : NetworkType
    {
        public const ushort ProtocolId = 204;
        public override ushort TypeID => ProtocolId;
        public bool CantBeAggressed { get; set; }
        public bool CantBeChallenged { get; set; }
        public bool CantTrade { get; set; }
        public bool CantBeAttackedByMutant { get; set; }
        public bool CantRun { get; set; }
        public bool ForceSlowWalk { get; set; }
        public bool CantMinimize { get; set; }
        public bool CantMove { get; set; }
        public bool CantAggress { get; set; }
        public bool CantChallenge { get; set; }
        public bool CantExchange { get; set; }
        public bool CantAttack { get; set; }
        public bool CantChat { get; set; }
        public bool CantBeMerchant { get; set; }
        public bool CantUseObject { get; set; }
        public bool CantUseTaxCollector { get; set; }
        public bool CantUseInteractive { get; set; }
        public bool CantSpeakToNPC { get; set; }
        public bool CantChangeZone { get; set; }
        public bool CantAttackMonster { get; set; }
        public bool CantWalk8Directions { get; set; }

        public ActorRestrictionsInformations(bool CantBeAggressed, bool CantBeChallenged, bool CantTrade, bool CantBeAttackedByMutant, bool CantRun, bool forceSlowWalk, bool CantMinimize, bool CantMove, bool CantAggress, bool CantChallenge, bool CantExchange, bool CantAttack, bool CantChat, bool CantBeMerchant, bool CantUseObject, bool CantUseTaxCollector, bool CantUseInteractive, bool CantSpeakToNPC, bool CantChangeZone, bool CantAttackMonster, bool CantWalk8Directions)
        {
            this.CantBeAggressed = CantBeAggressed;
            this.CantBeChallenged = CantBeChallenged;
            this.CantTrade = CantTrade;
            this.CantBeAttackedByMutant = CantBeAttackedByMutant;
            this.CantRun = CantRun;
            this.ForceSlowWalk = forceSlowWalk;
            this.CantMinimize = CantMinimize;
            this.CantMove = CantMove;
            this.CantAggress = CantAggress;
            this.CantChallenge = CantChallenge;
            this.CantExchange = CantExchange;
            this.CantAttack = CantAttack;
            this.CantChat = CantChat;
            this.CantBeMerchant = CantBeMerchant;
            this.CantUseObject = CantUseObject;
            this.CantUseTaxCollector = CantUseTaxCollector;
            this.CantUseInteractive = CantUseInteractive;
            this.CantSpeakToNPC = CantSpeakToNPC;
            this.CantChangeZone = CantChangeZone;
            this.CantAttackMonster = CantAttackMonster;
            this.CantWalk8Directions = CantWalk8Directions;
        }

        public ActorRestrictionsInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            var num = BooleanByteWrapper.SetFlag(0, 0, this.CantBeAggressed);
            num = BooleanByteWrapper.SetFlag(num, 1, this.CantBeChallenged);
            num = BooleanByteWrapper.SetFlag(num, 2, this.CantTrade);
            num = BooleanByteWrapper.SetFlag(num, 3, this.CantBeAttackedByMutant);
            num = BooleanByteWrapper.SetFlag(num, 4, this.CantRun);
            num = BooleanByteWrapper.SetFlag(num, 5, this.ForceSlowWalk);
            num = BooleanByteWrapper.SetFlag(num, 6, this.CantMinimize);
            writer.WriteByte(BooleanByteWrapper.SetFlag(num, 7, this.CantMove));
            var num1 = BooleanByteWrapper.SetFlag(0, 0, this.CantAggress);
            num1 = BooleanByteWrapper.SetFlag(num1, 1, this.CantChallenge);
            num1 = BooleanByteWrapper.SetFlag(num1, 2, this.CantExchange);
            num1 = BooleanByteWrapper.SetFlag(num1, 3, this.CantAttack);
            num1 = BooleanByteWrapper.SetFlag(num1, 4, this.CantChat);
            num1 = BooleanByteWrapper.SetFlag(num1, 5, this.CantBeMerchant);
            num1 = BooleanByteWrapper.SetFlag(num1, 6, this.CantUseObject);
            writer.WriteByte(BooleanByteWrapper.SetFlag(num1, 7, this.CantUseTaxCollector));
            var num2 = BooleanByteWrapper.SetFlag(0, 0, this.CantUseInteractive);
            num2 = BooleanByteWrapper.SetFlag(num2, 1, this.CantSpeakToNPC);
            num2 = BooleanByteWrapper.SetFlag(num2, 2, this.CantChangeZone);
            num2 = BooleanByteWrapper.SetFlag(num2, 3, this.CantAttackMonster);
            writer.WriteByte(BooleanByteWrapper.SetFlag(num2, 4, this.CantWalk8Directions));
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            CantBeAggressed = BooleanByteWrapper.GetFlag(flag, 0);
            CantBeChallenged = BooleanByteWrapper.GetFlag(flag, 1);
            CantTrade = BooleanByteWrapper.GetFlag(flag, 2);
            CantBeAttackedByMutant = BooleanByteWrapper.GetFlag(flag, 3);
            CantRun = BooleanByteWrapper.GetFlag(flag, 4);
            ForceSlowWalk = BooleanByteWrapper.GetFlag(flag, 5);
            CantMinimize = BooleanByteWrapper.GetFlag(flag, 6);
            CantMove = BooleanByteWrapper.GetFlag(flag, 7);
            flag = reader.ReadByte();
            CantAggress = BooleanByteWrapper.GetFlag(flag, 0);
            CantChallenge = BooleanByteWrapper.GetFlag(flag, 1);
            CantExchange = BooleanByteWrapper.GetFlag(flag, 2);
            CantAttack = BooleanByteWrapper.GetFlag(flag, 3);
            CantChat = BooleanByteWrapper.GetFlag(flag, 4);
            CantBeMerchant = BooleanByteWrapper.GetFlag(flag, 5);
            CantUseObject = BooleanByteWrapper.GetFlag(flag, 6);
            CantUseTaxCollector = BooleanByteWrapper.GetFlag(flag, 7);
            flag = reader.ReadByte();
            CantUseInteractive = BooleanByteWrapper.GetFlag(flag, 0);
            CantSpeakToNPC = BooleanByteWrapper.GetFlag(flag, 1);
            CantChangeZone = BooleanByteWrapper.GetFlag(flag, 2);
            CantAttackMonster = BooleanByteWrapper.GetFlag(flag, 3);
            CantWalk8Directions = BooleanByteWrapper.GetFlag(flag, 4);
        }

    }
}
