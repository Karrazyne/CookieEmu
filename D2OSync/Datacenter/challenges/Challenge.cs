// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Challenge")]
    public class Challenge : IDataObject
    {
        public const string MODULE = "Challenge";
        public bool DareAvailable;
        public uint DescriptionId;
        public int Id;
        public List<uint> IncompatibleChallenges;
        public uint NameId;
    }
}