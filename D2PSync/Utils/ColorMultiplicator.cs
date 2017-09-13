namespace D2PSync.Utils
{
    public class ColorMultiplicator
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public bool IsOne;

        public ColorMultiplicator(int param1, int param2, int param3, bool param4 = false)
        {
            Red = param1;
            Green = param2;
            Blue = param3;
            if (!param4 && param1 + param2 + param3 == 0)
                IsOne = true;
        }

        public static int Clamp(int param1, int param2, int param3)
        {
            return param1 > param3 ? param3 : (param1 < param2 ? param2 : param1);
        }

        public ColorMultiplicator Multiply(ColorMultiplicator param1)
        {
            if (IsOne)
                return param1;
            if (param1.IsOne)
                return this;
            var loc2 = new ColorMultiplicator(0, 0, 0)
            {
                Red = Red + param1.Red,
                Green = Green + param1.Green,
                Blue = Blue + param1.Blue
            };
            loc2.Red = Clamp(loc2.Red, -128, 127);
            loc2.Green = Clamp(loc2.Green, -128, 127);
            loc2.Blue = Clamp(loc2.Blue, -128, 127);
            loc2.IsOne = false;
            return loc2;
        }
    }
}
