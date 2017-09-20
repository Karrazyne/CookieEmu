using System;
using System.IO;
using D2PSync.Data.Elements;
using D2PSync.Database;

namespace D2PSync
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager.Connect("127.0.0.1", "root", "", "cookieemu");

            MapsManager.Init(@"D:\Dofus 2.43\app\content\maps");

           var map = MapsManager.FromId(154010884);

            /*using (var writer = new StreamWriter("./MapElement.txt"))
            {
                foreach (var layer in map.Layers)
                {
                    foreach (var cell in layer.Cells)
                    {
                        foreach (var element in cell.Elements)
                        {
                            if (element is GraphicalElement graphical)
                            {
                                if (graphical.Identifier == 0) continue;
                                writer.WriteLine($"ElementId {graphical.ElementId} ElementType {graphical.ElementType} Identifier {graphical.Identifier}");
                                DatabaseManager.ExecuteNonQuery($"INSERT INTO map_element SET ElementId = '{graphical.ElementId}', Identifier = '{graphical.Identifier}'");
                            }
                        }
                    }
                }
            }*/
            

            MapsManager.ParseAllMap();

            Console.WriteLine("Done");

            DatabaseManager.Close();
            Console.Read();
        }
    }
}
