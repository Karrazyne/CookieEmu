
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("AbuseReasons")]
    public class AbuseReasons : IDataObject
    {
        public const string MODULE = "AbuseReasons";
        public uint AbuseReasonId;
        public uint Mask;
        public int ReasonTextId;
    }
}