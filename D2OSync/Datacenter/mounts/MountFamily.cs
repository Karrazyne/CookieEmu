using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MountFamily")]
    public class MountFamily : IDataObject
    {
        public const string MODULE = "MountFamily";
        public string HeadUri;
        public uint Id;
        public uint NameId;
    }
}