using System;
using CookieEmu.API.Protocol;
using CookieEmu.Common.Console;
using CookieEmu.Game.Network;

namespace CookieEmu.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitializeLogger("Game");
            MessageIdentifier.Initialize();
            GameServer.Start();

            while (true)
                Console.Read();
        }
    }
}
