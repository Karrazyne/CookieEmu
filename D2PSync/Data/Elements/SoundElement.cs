using System;
using CookieEmu.API.IO;

namespace D2PSync.Data.Elements
{
    public class SoundElement : BasicElement
    {
        public int SoundId { get; set; }
        public int MinDelayBetweenLoops { get; set; }
        public int MaxDelayBetweenLoops { get; set; }
        public int BaseVolume { get; set; }
        public int FullVolumeDistance { get; set; }
        public int NullVolumeDistance { get; set; }

        public SoundElement(Cell param1) : base(param1) { }

        public override int ElementType => (int)ElementTypesEnum.Sound;

        public override void FromRaw(IDataReader param1, int param2)
        {
            var raw = param1;
            var mapVersion = param2;
            try
            {
                SoundId = raw.ReadInt();
                BaseVolume = raw.ReadShort();
                FullVolumeDistance = raw.ReadInt();
                NullVolumeDistance = raw.ReadInt();
                MinDelayBetweenLoops = raw.ReadShort();
                MaxDelayBetweenLoops = raw.ReadShort();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
