using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using CookieEmu.API.IO;
using D2PSync.Data;

namespace D2PSync
{
    public class MapsManager
    {
        private static D2pFileManager _d2PFileManager;

        public static void Init(string directory) => _d2PFileManager = new D2pFileManager(directory);

        public static void ParseAllMap() => _d2PFileManager.ParseAllMap();

        public static Map FromId(int id)
        {
            var str = id % 10 + "/" + id + ".dlm";
            var mapBytes = _d2PFileManager.GetMapBytes(str);
            if (mapBytes != null)
            {
                var stream = new MemoryStream(_d2PFileManager.GetMapBytes(str)){Position = 2};
                var stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                var buffer = new byte[8192];
                var destination = new MemoryStream();
                int read;
                while ((read = stream2.Read(buffer, 0, buffer.Length)) > 0)
                    destination.Write(buffer, 0, read);
                destination.Position = 0;
                var reader = new BigEndianReader(destination);
                var map = new Map();
                map.FromRaw(reader, Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4"));
                Array.Clear(mapBytes, 0, mapBytes.Length);
                return map;
            }
            return null;
        }
    }
}
