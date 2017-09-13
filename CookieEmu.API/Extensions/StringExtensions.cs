using System;
using System.Text;

namespace CookieEmu.API.Extensions
{
    public static class StringExtensions
    {
        public static string RandomString(this Random random, int size)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                stringBuilder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))));
            }
            return stringBuilder.ToString();
        }
    }
}
