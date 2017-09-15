// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MonsterRaces")]
    public class MonsterRace : IDataObject
    {
        public const string MODULE = "MonsterRaces";
        public int Id;
        public List<uint> Monsters;
        public uint NameId;
        public int SuperRaceId;
    }
}