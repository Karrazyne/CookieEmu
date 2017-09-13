using System;
using CookieEmu.API.IO;

namespace D2PSync.Data
{
    public class CellData
    {
        public uint Id { get; set; }
        public int Speed { get; set; }
        public uint MapChangeData { get; set; }
        public uint MoveZone { get; set; }
        public int Floor { get; set; }
        public bool Mov;
        public bool Los;
        public bool NonWalkableDuringFight;
        public bool Red { get; set; }
        public bool Blue { get; set; }
        public bool FarmCell { get; set; }
        public bool HavenbagCell { get; set; }
        public bool Visible { get; set; }
        public bool NonWalkableDuringRp { get; set; }
        public bool UseTopArrow => (_arrow & 1) != 0;
        public bool UseBottomArrow => (_arrow & 2) != 0;
        public bool UseRightArrow => (_arrow & 4) != 0;
        public bool UseLeftArrow => (_arrow & 8) != 0;

        private int _losmov = 3;
        private readonly Map _map;
        private int _arrow;

        public CellData(Map param1, uint param2)
        {
            Id = param2;
            _map = param1;
        }

        public void FromRaw(IDataReader param1)
        {
            var raw = param1;
            try
            {
                Floor = raw.ReadByte() * 10;
                if (Floor == -1280)
                    return;
                if (_map.MapVersion >= 9)
                {
                    int tmpbytesv9 = raw.ReadShort();
                    Mov = (tmpbytesv9 & 1) == 0;
                    NonWalkableDuringFight = (tmpbytesv9 & 2) != 0;
                    NonWalkableDuringRp = (tmpbytesv9 & 4) != 0;
                    Los = (tmpbytesv9 & 8) == 0;
                    Blue = (tmpbytesv9 & 16) != 0;
                    Red = (tmpbytesv9 & 32) != 0;
                    Visible = (tmpbytesv9 & 64) != 0;
                    FarmCell = (tmpbytesv9 & 128) != 0;
                    bool topArrow;
                    bool bottomArrow;
                    bool rightArrow;
                    bool leftArrow;
                    if (_map.MapVersion >= 10)
                    {
                        HavenbagCell = (tmpbytesv9 & 256) != 0;
                        topArrow = (tmpbytesv9 & 512) != 0;
                        bottomArrow = (tmpbytesv9 & 1024) != 0;
                        rightArrow = (tmpbytesv9 & 2048) != 0;
                        leftArrow = (tmpbytesv9 & 4096) != 0;
                    }
                    else
                    {
                        topArrow = (tmpbytesv9 & 256) != 0;
                        bottomArrow = (tmpbytesv9 & 512) != 0;
                        rightArrow = (tmpbytesv9 & 1024) != 0;
                        leftArrow = (tmpbytesv9 & 2048) != 0;
                    }
                    if (topArrow)
                        _map.TopArrowCell.Add(Id);
                    if (bottomArrow)
                        _map.BottomArrowCell.Add(Id);
                    if (rightArrow)
                        _map.RightArrowCell.Add(Id);
                    if (leftArrow)
                        _map.LeftArrowCell.Add(Id);
                }
                else
                {
                    _losmov = raw.ReadByte();
                    Los = (_losmov & 2) >> 1 == 1;
                    Mov = (_losmov & 1) == 1;
                    Visible = (_losmov & 64) >> 6 == 1;
                    FarmCell = (_losmov & 32) >> 5 == 1;
                    Blue = (_losmov & 16) >> 4 == 1;
                    Red = (_losmov & 8) >> 3 == 1;
                    NonWalkableDuringRp = (_losmov & 128) >> 7 == 1;
                    NonWalkableDuringFight = (_losmov & 4) >> 2 == 1;
                }
                Speed = raw.ReadByte();
                MapChangeData = raw.ReadByte();
                if (_map.MapVersion > 5)
                    MoveZone = raw.ReadByte();
                if (_map.MapVersion > 7 && _map.MapVersion < 9)
                {
                    int tmpBits = raw.ReadByte();
                    _arrow = 15 & tmpBits;
                    if (UseTopArrow)
                        _map.TopArrowCell.Add(Id);
                    if (UseBottomArrow)
                        _map.BottomArrowCell.Add(Id);
                    if (UseLeftArrow)
                        _map.LeftArrowCell.Add(Id);
                    if (UseRightArrow)
                        _map.RightArrowCell.Add(Id);
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
