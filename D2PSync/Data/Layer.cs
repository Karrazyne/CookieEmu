using System;
using CookieEmu.API.IO;

namespace D2PSync.Data
{
    public class Layer
    {
        public const uint LayerGround = 0;
        public const uint LayerAdditionalGround = 1;
        public const uint LayerDecor = 2;
        public const uint LayerAdditionalDecor = 3;

        public int LayerId { get; set; }
        public int RefCell = 0;
        public int CellsCount { get; set; }
        public Cell[] Cells { get; set; }

        private Map _map;

        public Layer(Map param1)
        {
            _map = param1;
        }

        public void FromRaw(IDataReader param1, int param2)
        {
            var raw = param1;
            var mapVersion = param2;
            try
            {
                LayerId = mapVersion >= 9 ? raw.ReadByte() : raw.ReadInt();
                CellsCount = raw.ReadShort();
                Cells = new Cell[CellsCount];
                for (var i = 0; i < CellsCount; i++)
                {
                    var c = new Cell(this);
                    c.FromRaw(raw, mapVersion);
                    Cells[i] = c;
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
