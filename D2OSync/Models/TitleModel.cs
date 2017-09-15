using System;
using D2OSync.D2i;
using D2OSync.Database;
using D2OSync.Datacenter;

namespace D2OSync.Models
{
    public class TitleModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int NameFemaleId { get; set; }
        public int NameMaleId { get; set; }
        public int Visible { get; set; }
        public string TextFemale { get; set; }
        public string TextMale { get; set; }

        public string Query { get; set; }

        private Title Title { get; }

        public TitleModel(Title title)
        {
            Title = title;
            SetTitle();
        }

        private void SetTitle()
        {
            Id = Title.Id;
            CategoryId = Title.CategoryId;
            NameFemaleId = (int) Title.NameFemaleId;
            NameMaleId = (int) Title.NameMaleId;
            Visible = Title.Visible ? 1 : 0;
            TextFemale = FastD2IReader.Instance.GetText(NameFemaleId).Replace("'", "");
            TextMale = FastD2IReader.Instance.GetText(NameMaleId).Replace("'", "");
            Console.WriteLine($@"Title {Id} parsed");
            GenerateQuery();
        }

        private void GenerateQuery()
        {
            Query =
                $"INSERT INTO titles SET Id = '{Id}', CategoryId = '{CategoryId}', NameFemaleId = '{NameFemaleId}', NameMaleId = '{NameMaleId}', Visible = '{Visible}', TextFemale = '{TextFemale}', TextMale = '{TextMale}'";
            DatabaseManager.ExecuteNonQuery(Query);
            Console.WriteLine(@"Added to sql");
        }
    }
}
