using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("AlignmentTitles")]
    public class AlignmentTitle : IDataObject
    {
        public const string MODULE = "AlignmentTitles";
        public List<int> NamesId;
        public List<int> ShortsId;
        public int SideId;
    }
}