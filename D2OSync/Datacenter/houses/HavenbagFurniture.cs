// Generated on 12/06/2016 11:35:50

using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("HavenbagFurnitures")]
    public class HavenbagFurniture : IDataObject
    {
        public const string MODULE = "HavenbagFurnitures";
        public bool BlocksMovement;
        public uint CellsHeight;
        public uint CellsWidth;
        public int Color;
        public int ElementId;
        public bool IsStackable;
        public int LayerId;
        public uint Order;
        public int SkillId;
        public int ThemeId;
        public int TypeId;
    }
}