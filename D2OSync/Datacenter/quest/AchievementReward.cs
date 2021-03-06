// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("AchievementRewards")]
    public class AchievementReward : IDataObject
    {
        public const string MODULE = "AchievementRewards";
        public uint AchievementId;
        public List<uint> EmotesReward;
        public uint Id;
        public List<uint> ItemsQuantityReward;
        public List<uint> ItemsReward;
        public int LevelMax;
        public int LevelMin;
        public List<uint> OrnamentsReward;
        public List<uint> SpellsReward;
        public List<uint> TitlesReward;
    }
}