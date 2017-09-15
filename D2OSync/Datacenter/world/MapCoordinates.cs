// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MapCoordinates")]
    public class MapCoordinates : IDataObject
    {
        public const string MODULE = "MapCoordinates";
        public uint CompressedCoords;
        public List<int> MapIds;
    }
}