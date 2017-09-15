// Generated on 12/06/2016 11:35:51

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Notifications")]
    public class Notification : IDataObject
    {
        public const string MODULE = "Notifications";
        public int IconId;
        public int Id;
        public uint MessageId;
        public uint TitleId;
        public string Trigger;
        public int TypeId;
    }
}