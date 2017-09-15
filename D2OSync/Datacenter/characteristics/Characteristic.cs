// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Characteristics")]
    public class Characteristic : IDataObject
    {
        public const string MODULE = "Characteristics";
        public string Asset;
        public int CategoryId;
        public int Id;
        public string Keyword;
        public uint NameId;
        public int Order;
        public bool Upgradable;
        public bool Visible;
    }
}