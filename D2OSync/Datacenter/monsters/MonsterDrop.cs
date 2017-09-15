// Generated on 12/06/2016 11:35:51

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("MonsterDrop")]
    public class MonsterDrop : IDataObject
    {
        public int Count;
        public uint DropId;
        public bool HasCriteria;
        public int MonsterId;
        public int ObjectId;
        public float PercentDropForGrade1;
        public float PercentDropForGrade2;
        public float PercentDropForGrade3;
        public float PercentDropForGrade4;
        public float PercentDropForGrade5;
    }
}