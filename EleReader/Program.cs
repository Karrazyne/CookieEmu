using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EleReader.Datas;

namespace EleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager.Connect("127.0.0.1", "root", "", "cookieemu");
           var reader = new EleReader("./elements.ele");
            EleGraphicalData tempElem;
            var elem = reader.ReadElements();

            /*foreach (var element in elem.GraphicalDatas.Values)
            {
                if (element is EntityGraphicalElementData entity)
                {
                    if (entity.EntityLook == "{660}")
                    {
                        DatabaseManager.ExecuteNonQuery(
                            $"INSERT INTO map_interactives SET Identifier = '{entity.Id}', ElementTypeId = '38', SkillId = '45'");
                        Console.WriteLine($"INSERT INTO map_interactives SET Identifier = '{entity.Id}', ElementTypeId = '38', SkillId = '45'");
                    }
                    DatabaseManager.ExecuteNonQuery(
                        $"INSERT INTO elements_ele SET Identifier = '{entity.Id}', EntityLook = '{entity.EntityLook}'");
                    Console.WriteLine($"INSERT INTO elements_ele SET Identifier = '{entity.Id}', EntityLook = '{entity.EntityLook}'");

                }
            }*/

            tempElem = elem.GraphicalDatas[29828];
            Console.WriteLine("done");
            Console.Read();
        }
    }
}
