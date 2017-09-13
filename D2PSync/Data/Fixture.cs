using System;
using CookieEmu.API.IO;
using D2PSync.Utils;

namespace D2PSync.Data
{
    public class Fixture
    {
        public int FixtureId { get; set; }
        public Point Offset { get; set; }
        public int Hue { get; set; }
        public int RedMultiplier { get; set; }
        public int GreenMultiplier { get; set; }
        public int BlueMultiplier { get; set; }
        public uint Alpha { get; set; }
        public int XScale { get; set; }
        public int YScale { get; set; }
        public int Rotation { get; set; }

        private Map _map;

        public Fixture(Map param1)
        {
            _map = param1;
        }

        public void FromRaw(IDataReader param1)
        {
            var raw = param1;
            try
            {
                FixtureId = raw.ReadInt();
                Offset = new Point
                {
                    X = raw.ReadShort(),
                    Y = raw.ReadShort()
                };
                Rotation = raw.ReadShort();
                XScale = raw.ReadShort();
                YScale = raw.ReadShort();
                RedMultiplier = raw.ReadByte();
                GreenMultiplier = raw.ReadByte();
                BlueMultiplier = raw.ReadByte();
                Hue = RedMultiplier | GreenMultiplier | BlueMultiplier;
                Alpha = raw.ReadByte();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
