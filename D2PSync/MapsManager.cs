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
    }
}
