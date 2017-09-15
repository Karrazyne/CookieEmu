// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("SmileyPacks")]
    public class SmileyPack : IDataObject
    {
        public const string MODULE = "SmileyPacks";
        public uint Id;
        public uint NameId;
        public uint Order;
        public List<uint> Smileys;
    }
}