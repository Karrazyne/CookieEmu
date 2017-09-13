using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol;
using CookieEmu.Auth.Network;
using CookieEmu.Common.Console;

namespace CookieEmu.Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitializeLogger("Auth");
            MessageIdentifier.Initialize();
            AuthServer.Start();

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
