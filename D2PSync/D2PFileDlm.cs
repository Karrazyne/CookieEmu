using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using CookieEmu.API.IO;
using D2PSync.Data;
using D2PSync.Data.Elements;
using D2PSync.Database;
using D2PSync.Utils;

namespace D2PSync
{
    public class D2PFileDlm
    {
        private readonly object _checkLock;
        private readonly FileStream _d2PFileStream;

        private readonly Dictionary<string, int[]> _filenameDataDictionnary;
        private readonly BigEndianReader _reader;

        public D2PFileDlm(string d2PFilePath)
        {
            _d2PFileStream = new FileStream(d2PFilePath, FileMode.Open, FileAccess.Read);
            _reader = new BigEndianReader(_d2PFileStream);
            _filenameDataDictionnary = new Dictionary<string, int[]>();
            _checkLock = RuntimeHelpers.GetObjectValue(new object());
            var num = Convert.ToByte(_reader.ReadByte() + _reader.ReadByte());
            if (num != 3) return;
            _d2PFileStream.Position = _d2PFileStream.Length - 24;
            var num2 = Convert.ToInt32(_reader.ReadUInt());
            _reader.ReadUInt();
            var num3 = Convert.ToInt32(_reader.ReadUInt());
            var num4 = Convert.ToInt32(_reader.ReadUInt());
            var num1 = Convert.ToInt32(_reader.ReadUInt());
            var num9 = Convert.ToInt32(_reader.ReadUInt());
            _d2PFileStream.Position = num3;
            var num5 = num4;
            var i = 1;
            while (i <= num5)
            {
                var key = _reader.ReadUTF();
                var num7 = _reader.ReadInt() + num2;
                var num8 = _reader.ReadInt();
                _filenameDataDictionnary.Add(key, new[]
                {
                    num7,
                    num8
                });
                i += 1;
            }
        }

        public bool ExistsDlm(string dlmName)
        {
            return _filenameDataDictionnary.ContainsKey(dlmName);
        }

        public byte[] ReadFile(string fileName)
        {
            lock (_checkLock)
            {
                var numArray = _filenameDataDictionnary[fileName];
                _d2PFileStream.Position = numArray[0];
                return _reader.ReadBytes(numArray[1]);
            }
        }

        public void ParseMap()
        {
            foreach (var map in _filenameDataDictionnary)
            {
                var tempData = ReadFile(map.Key);
                if (tempData == null) continue;
                var stream = new MemoryStream(tempData) { Position = 2 };
                var stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                var buffer = new byte[8192];
                var destination = new MemoryStream();
                int read;
                while ((read = stream2.Read(buffer, 0, buffer.Length)) > 0)
                    destination.Write(buffer, 0, read);
                destination.Position = 0;
                var reader = new BigEndianReader(destination);
                var tempMap = new Map();
                tempMap.FromRaw(reader, Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4"));
                Array.Clear(tempData, 0, tempData.Length);
                var data = new MapInfos(tempMap);
                data.SetMap();
                //DatabaseManager.ExecuteNonQuery(data.GenerateQuery());

                GetQuery(tempMap);

                //Console.WriteLine($"({Constants.MapCounter++}) Map -> {data.MapId} successfuly imported.");
            }
        }

        private static void GetQuery(Map tempMap)
        {
            foreach (var layer in tempMap.Layers)
            {
                foreach (var cell in layer.Cells)
                {
                    foreach (var element in cell.Elements)
                    {
                        if (element is GraphicalElement graphical)
                        {
                            if (DatabaseManager.OrmeIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '30', SkillId = '35', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Orme {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.OrgeIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '43', SkillId = '53', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Orge {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.AvoineIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '45', SkillId = '57', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Avoine {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.ChanvreIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '46', SkillId = '54', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Chanvre {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.SeigleIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '44', SkillId = '52', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Seigle {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.MaltIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '47', SkillId = '58', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Malt {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.MilletIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '47', SkillId = '58', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Millet {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.BambouSacreIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '110', SkillId = '158', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Bambou Sacrée {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.BambouSombreIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '109', SkillId = '155', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Bambou Sombre {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.EdelweissIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '61', SkillId = '54', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Edelweiss {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.OrchideeIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '68', SkillId = '73', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Orchidée Freyesque {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.MentheIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '66', SkillId = '72', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Menthe Sauvage {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                            else if (DatabaseManager.CobaltIdentifier.Contains((uint)graphical.ElementId))
                            {
                                DatabaseManager.ExecuteNonQuery(
                                    $"INSERT INTO map_interactives SET ElementId = '{graphical.Identifier}', ElementTypeId = '37', SkillId = '28', MapId = '{tempMap.Id}', CellId = '{cell.CellId}'");

                                Console.WriteLine($"add Cobalt {graphical.Identifier} on {tempMap.Id} / {cell.CellId}");
                            }
                        }
                    }
                }
            }
        }
    }
}