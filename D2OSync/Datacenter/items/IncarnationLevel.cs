// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("IncarnationLevels")]
    public class IncarnationLevel : IDataObject
    {
        public const string MODULE = "IncarnationLevels";
        public int Id;
        public int IncarnationId;
        public int Level;
        public uint RequiredXp;
    }
}