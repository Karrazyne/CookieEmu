using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
        public const string MODULE = "MountBone";
        public uint Id;
    }
}