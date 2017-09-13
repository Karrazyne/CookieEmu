using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D2PSync
{
    public sealed class D2pFileManager
    {
        private readonly List<D2PFileDlm> _listD2PFileDlm = new List<D2PFileDlm>();
        
        public D2pFileManager(string path)
        {
            foreach (var fileLoopVariable in Directory.GetFiles(path))
            {
                var file = fileLoopVariable;
                var info = new FileInfo(file);
                if (info.Extension.ToUpper() == ".D2P")
                    _listD2PFileDlm.Add(new D2PFileDlm(file));
            }
        }

        public byte[] GetMapBytes(string name)
        {
            var dlm = _listD2PFileDlm.FirstOrDefault(f => f.ExistsDlm(name));
            return dlm?.ReadFile(name);
        }

        public void ParseAllMap()
        {
            foreach(var map in _listD2PFileDlm)
                map.ParseMap();
        }
    }
}
