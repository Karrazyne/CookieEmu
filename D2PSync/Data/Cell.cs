using System;
using CookieEmu.API.IO;
using D2PSync.Data.Elements;

namespace D2PSync.Data
{
    public class Cell
    {

        public int CellId { get; set; }
        public int ElementsCount { get; set; }
        public BasicElement[] Elements { get; set; }

        private Layer _layer;

        public Cell(Layer param1)
        {
            _layer = param1;
        }

        public void FromRaw(IDataReader param1, int param2)
        {
            var raw = param1;
            var mapVersion = param2;
            try
            {
                CellId = raw.ReadShort();
                ElementsCount = raw.ReadShort();
                Elements = new BasicElement[ElementsCount];
                for (var i = 0; i < ElementsCount; i++)
                {
                    var be = BasicElement.GetElementFromType(raw.ReadByte(), this);
                    be.FromRaw(raw, mapVersion);
                    Elements[i] = be;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
