using System;
using CookieEmu.API.IO;
using D2PSync.Utils;

namespace D2PSync.Data.Elements
{
    public class GraphicalElement : BasicElement
    {
        public int ElementId { get; private set; }
        public ColorMultiplicator Hue { get; private set; }
        public ColorMultiplicator Shadow { get; private set; }
        public ColorMultiplicator FinalTeint { get; private set; }
        public Point Offset { get; private set; }
        public Point PixelOffset { get; private set; }
        public int Altitude { get; private set; }
        public uint Identifier { get; private set; }

        public GraphicalElement(Cell param1) : base(param1)
        {
        }

        public override int ElementType => (int)ElementTypesEnum.Graphical;

        public ColorMultiplicator GetColorMultiplicator => FinalTeint;

        private void CalculateFinalTeint()
        {
            var loc1 = Hue.Red + Shadow.Red;
            var loc2 = Hue.Green + Shadow.Green;
            var loc3 = Hue.Blue + Shadow.Blue;
            loc1 = ColorMultiplicator.Clamp((loc1 + 128) * 2, 0, 512);
            loc2 = ColorMultiplicator.Clamp((loc2 + 128) * 2, 0, 512);
            loc3 = ColorMultiplicator.Clamp((loc3 + 128) * 2, 0, 512);
            FinalTeint = new ColorMultiplicator(loc1, loc2, loc3, true);
        }

        public override void FromRaw(IDataReader param1, int param2)
        {
            var raw = param1;
            var mapVersion = param2;
            try
            {
                ElementId = (int)raw.ReadUInt();
                Hue = new ColorMultiplicator(raw.ReadByte(), raw.ReadByte(), raw.ReadByte());
                Shadow = new ColorMultiplicator(raw.ReadByte(), raw.ReadByte(), raw.ReadByte());
                Offset = new Point();
                PixelOffset = new Point();
                if (mapVersion <= 4)
                {
                    Offset.X = raw.ReadByte();
                    Offset.Y = raw.ReadByte();
                    PixelOffset.X = Offset.X * Constants.CellHalfWidth;
                    PixelOffset.Y = (int)(Offset.Y * Constants.CellHalfHeight);
                }
                else
                {
                    PixelOffset.X = raw.ReadShort();
                    PixelOffset.Y = raw.ReadShort();
                    Offset.X = PixelOffset.X / Constants.CellHalfWidth;
                    Offset.Y = (int)(PixelOffset.Y / Constants.CellHalfHeight);
                }
                Altitude = raw.ReadByte();
                Identifier = raw.ReadUInt();
                CalculateFinalTeint();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
