// Generated on 12/06/2016 11:35:52

using D2OSync.D2o;
using D2OSync.D2o.other;

namespace D2OSync.Datacenter
{
    [D2oClass("Areas")]
    public class Area : IDataObject
    {
        public const string MODULE = "Areas";
        public Rectangle Bounds;
        public bool ContainHouses;
        public bool ContainPaddocks;
        public bool HasWorldMap;
        public int Id;
        public uint NameId;
        public int SuperAreaId;
        public uint WorldmapId;
    }
}