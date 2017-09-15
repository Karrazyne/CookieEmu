// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("CharacteristicCategories")]
    public class CharacteristicCategory : IDataObject
    {
        public const string MODULE = "CharacteristicCategories";
        public List<uint> CharacteristicIds;
        public int Id;
        public uint NameId;
        public int Order;
    }
}