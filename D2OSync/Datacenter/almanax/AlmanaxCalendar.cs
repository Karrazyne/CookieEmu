// Generated on 12/06/2016 11:35:49

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("AlmanaxCalendars")]
    public class AlmanaxCalendar : IDataObject
    {
        public const string MODULE = "AlmanaxCalendars";
        public List<int> BonusesIds;
        public uint DescId;
        public int Id;
        public uint NameId;
        public int NpcId;
    }
}