// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Weapon")]
    public class Weapon : Item
    {
        public int ApCost;
        public bool CastInDiagonal;
        public bool CastInLine;
        public bool CastTestLos;
        public int CriticalFailureProbability;
        public int CriticalHitBonus;
        public int CriticalHitProbability;
        public uint MaxCastPerTurn;
        public int MinRange;
        public int Range;
    }
}