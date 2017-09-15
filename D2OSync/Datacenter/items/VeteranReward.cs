// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("VeteranRewards")]
    public class VeteranReward : IDataObject
    {
        public const string MODULE = "VeteranRewards";
        public int Id;
        public uint ItemGID;
        public uint ItemQuantity;
        public uint RequiredSubDays;
    }
}