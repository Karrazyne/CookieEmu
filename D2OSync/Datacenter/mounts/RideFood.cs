using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("RideFood")]
    public class RideFood : IDataObject
    {
        public const string MODULE = "RideFood";
        public uint Gid;
        public uint TypeId;
    }
}