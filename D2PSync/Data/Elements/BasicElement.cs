using System;
using CookieEmu.API.IO;

namespace D2PSync.Data.Elements
{
    public abstract class BasicElement
    {
        protected BasicElement(Cell param1)
        {
            Cell = param1;
        }

        public static BasicElement GetElementFromType(int param1, Cell param2)
        {
            switch (param1)
            {
                case (int)ElementTypesEnum.Graphical:
                    return new GraphicalElement(param2);
                case (int)ElementTypesEnum.Sound:
                    return new SoundElement(param2);
                default:
                    throw new Exception($"Un élément de type inconnu {param1} a été trouvé sur la celulle {param2.CellId}!");
            }
        }

        public Cell Cell { get; }

        public abstract void FromRaw(IDataReader param1, int param2);

        public abstract int ElementType { get; }
    }
}
