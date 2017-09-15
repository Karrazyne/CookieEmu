// Generated on 12/06/2016 11:35:51

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("SpeakingItemsText")]
    public class SpeakingItemText : IDataObject
    {
        public const string MODULE = "SpeakingItemsText";
        public int TextId;
        public int TextLevel;
        public float TextProba;
        public string TextRestriction;
        public int TextSound;
        public uint TextStringId;
    }
}