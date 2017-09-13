using System;
using D2PSync.Database;

namespace D2PSync
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager.Connect("127.0.0.1", "root", "", "cookieemu");

            MapsManager.Init(@"D:\Dofus 2.43\app\content\maps");
            MapsManager.ParseAllMap();

            Console.WriteLine("Done");

            DatabaseManager.Close();
            Console.Read();
        }
    }
}
