using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("RankNames")]
    public class RankName : IDataObject
    {
        public const string MODULE = "RankNames";
        public int Id;
        public uint NameId;
        public int Order;
    }
}