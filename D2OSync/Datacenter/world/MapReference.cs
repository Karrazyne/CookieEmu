using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MapReferences")]
    public class MapReference : IDataObject
    {
        public const string MODULE = "MapReferences";
        public int CellId;
        public int Id;
        public uint MapId;
    }
}