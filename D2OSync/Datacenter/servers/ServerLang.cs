using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("ServerLang")]
    public class ServerLang : IDataObject
    {
        public const string MODULE = "ServerLang";
        public int Id;
        public string LangCode;
        public uint NameId;
    }
}