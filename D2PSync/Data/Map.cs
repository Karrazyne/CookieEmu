using System;
using System.Collections.Generic;
using System.IO;
using CookieEmu.API.IO;
using D2PSync.Utils;

namespace D2PSync.Data
{
    public class Map
    {
        public int MapVersion { get; set; }
        public bool Encrypted { get; set; }
        public uint EncryptionVersion { get; set; }
        public int GroundCrc { get; set; }
        public int ZoomScale = 1;
        public int ZoomOffsetX { get; set; }
        public int ZoomOffsetY { get; set; }
        public int GroundCacheCurrentlyUsed = 0;
        public int Id { get; set; }
        public int RelativeId { get; set; }
        public int MapType { get; set; }
        public int BackgroundsCount { get; set; }
        public Fixture[] BackgroundsFixtures { get; set; }
        public int ForegroundsCount { get; set; }
        public Fixture[] ForegroundFixtures { get; set; }
        public int SubAreaId { get; set; }
        public int ShadowBonusOnEntities { get; set; }
        public uint GridColor { get; set; }
        public uint BackgroundColor { get; set; }
        public int BackgroundRed { get; set; }
        public int BackgroundGreen { get; set; }
        public int BackgroundBlue { get; set; }
        public int BackgroundAlpha { get; set; }
        public int TopNeighbourId { get; set; }
        public int BottomNeighbourId { get; set; }
        public int LeftNeighbourId { get; set; }
        public int RightNeighbourId { get; set; }
        public bool UseLowPassFilter { get; set; }
        public bool UseReverb { get; set; }
        public int PresetId { get; set; }
        public int CellsCount { get; set; }
        public int LayersCount { get; set; }
        public bool IsUsingNewMovementSystem;
        public Layer[] Layers { get; set; }
        public CellData[] Cells { get; set; }

        public List<uint> TopArrowCell { get; set; }
        public List<uint> LeftArrowCell { get; set; }
        public List<uint> BottomArrowCell { get; set; }
        public List<uint> RightArrowCell { get; set; }

        public Map()
        {
            TopArrowCell = new List<uint>();
            LeftArrowCell = new List<uint>();
            BottomArrowCell = new List<uint>();
            RightArrowCell = new List<uint>();
        }

        public void FromRaw(IDataReader param1, byte[] param2)
        {
            var oldMvtSystem = -1;
            var raw = param1;
            var decryptionKey = param2;
            try
            {
                int header = raw.ReadSByte();
                if (header != 77)
                    throw new Exception("Unknown file format.");
                MapVersion = raw.ReadByte();
                Id = (int)raw.ReadUInt();
                if (MapVersion >= 7)
                {
                    Encrypted = raw.ReadBoolean();
                    EncryptionVersion = raw.ReadByte();
                    var dataLen = raw.ReadInt();
                    if (Encrypted)
                    {
                        if (decryptionKey.Length < 1)
                            throw new Exception("Map decryption key is empty");
                        var encryptedData = raw.ReadBytes(dataLen);
                        for (var i = 0; i < encryptedData.Length; i++)
                            encryptedData[i] = (byte)(encryptedData[i] ^ decryptionKey[i % decryptionKey.Length]);
                        raw = new BigEndianReader(new MemoryStream(encryptedData));
                    }
                }
                RelativeId = (int)raw.ReadUInt();
                MapType = raw.ReadByte();
                SubAreaId = raw.ReadInt();
                TopNeighbourId = raw.ReadInt();
                BottomNeighbourId = raw.ReadInt();
                LeftNeighbourId = raw.ReadInt();
                RightNeighbourId = raw.ReadInt();
                ShadowBonusOnEntities = (int)raw.ReadUInt();
                if (MapVersion >= 9)
                {
                    var readColor = raw.ReadInt();
                    BackgroundAlpha = (int)((readColor & 4278190080) >> 32);
                    BackgroundRed = (readColor & 16711680) >> 16;
                    BackgroundGreen = (readColor & 65280) >> 8;
                    BackgroundBlue = readColor & 255;
                    readColor = (int)raw.ReadUInt();
                    var gridAlpha = (int)((readColor & 4278190080) >> 32);
                    var gridRed = (readColor & 16711680) >> 16;
                    var gridGreen = (readColor & 65280) >> 8;
                    var gridBlue = readColor & 255;
                    GridColor = (uint)((gridAlpha & 255) << 32 | (gridRed & 255) << 16 | (gridGreen & 255) << 8 | gridBlue & 255);
                }
                else if (MapVersion >= 3)
                {
                    BackgroundRed = raw.ReadByte();
                    BackgroundGreen = raw.ReadByte();
                    BackgroundBlue = raw.ReadByte();
                }
                BackgroundColor = (uint)((BackgroundAlpha & 255) << 32 | (BackgroundRed & 255) << 16 |
                                         (BackgroundGreen & 255) << 8 | BackgroundBlue & 255);
                if (MapVersion >= 4)
                {
                    ZoomScale = raw.ReadUShort() / 100;
                    ZoomOffsetX = raw.ReadShort();
                    ZoomOffsetY = raw.ReadShort();
                    if (ZoomScale < 1)
                    {
                        ZoomScale = 1;
                        ZoomOffsetY = 0;
                        ZoomOffsetX = 0;
                    }
                }
                UseLowPassFilter = raw.ReadByte() == 1;
                UseReverb = raw.ReadByte() == 1;
                if (UseReverb)
                    PresetId = raw.ReadInt();
                else
                    PresetId = -1;
                BackgroundsCount = raw.ReadByte();
                BackgroundsFixtures = new Fixture[BackgroundsCount];
                for (var i = 0; i < BackgroundsCount; i++)
                {
                    var bg = new Fixture(this);
                    bg.FromRaw(raw);
                    BackgroundsFixtures[i] = bg;
                }
                ForegroundsCount = raw.ReadByte();
                ForegroundFixtures = new Fixture[ForegroundsCount];
                for (var i = 0; i < ForegroundsCount; i++)
                {
                    var fg = new Fixture(this);
                    fg.FromRaw(raw);
                    ForegroundFixtures[i] = fg;
                }
                CellsCount = Constants.MapCellsCount;
                raw.ReadInt();
                GroundCrc = raw.ReadInt();
                LayersCount = raw.ReadByte();
                Layers = new Layer[LayersCount];
                for (var i = 0; i < LayersCount; i++)
                {
                    var la = new Layer(this);
                    la.FromRaw(raw, MapVersion);
                    Layers[i] = la;
                }
                Cells = new CellData[CellsCount];
                for (var i = 0; i < CellsCount; i++)
                {
                    var cd = new CellData(this, (uint)i);
                    cd.FromRaw(raw);
                    if (oldMvtSystem == -1)
                        oldMvtSystem = (int)cd.MoveZone;
                    if (cd.MoveZone != oldMvtSystem)
                        IsUsingNewMovementSystem = true;
                    Cells[i] = cd;
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
