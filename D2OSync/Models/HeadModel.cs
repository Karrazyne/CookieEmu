using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2OSync.Database;
using D2OSync.Datacenter;

namespace D2OSync.Models
{
    public class HeadModel
    {
        public int Id { get; set; }
        public string Skin { get; set; }

        private Head Head { get; }

        public string Query { get; set; }

        public HeadModel(Head head)
        {
            Head = head;
            SetHead();
        }

        private void SetHead()
        {
            Id = Head.Id;
            Skin = Head.Skins;

            GenerateQuery();
        }

        private void GenerateQuery()
        {
            Query = $"INSERT INTO `breeds_heads` VALUES ('{Id}', '{Skin}');";
            DatabaseManager.ExecuteNonQuery(Query);
            Console.WriteLine($"Head {Id} added to sql");
        }
    }
}
