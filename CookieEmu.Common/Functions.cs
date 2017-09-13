using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Common
{
    public class Functions
    {
        public static int ReturnUnixTimeStamp(DateTime date)
            => (int)date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
    }
}
