// Generated on 12/06/2016 11:35:52

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("SoundAnimations")]
    public class SoundAnimation : IDataObject
    {
        public int AutomationDuration;
        public int AutomationFadeIn;
        public int AutomationFadeOut;
        public int AutomationVolume;
        public string Filename;
        public uint Id;
        public string Label;
        public string MODULE = "SoundAnimations";
        public string Name;
        public bool NoCutSilence;
        public int Rolloff;
        public uint StartFrame;
        public int Volume;
    }
}