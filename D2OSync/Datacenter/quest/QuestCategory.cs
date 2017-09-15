// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("QuestCategory")]
    public class QuestCategory : IDataObject
    {
        public const string MODULE = "QuestCategory";
        public uint Id;
        public uint NameId;
        public uint Order;
        public List<uint> QuestIds;
    }
}