// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("InfoMessages")]
    public class InfoMessage : IDataObject
    {
        public const string MODULE = "InfoMessages";
        public uint MessageId;
        public uint TextId;
        public uint TypeId;
    }
}