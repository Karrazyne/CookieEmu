// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Companions")]
    public class Companion : IDataObject
    {
        public const string MODULE = "Companions";
        public uint AssetId;
        public List<uint> Characteristics;
        public int CreatureBoneId;
        public uint DescriptionId;
        public int Id;
        public string Look;
        public uint NameId;
        public List<uint> Spells;
        public uint StartingSpellLevelId;
        public bool WebDisplay;
    }
}