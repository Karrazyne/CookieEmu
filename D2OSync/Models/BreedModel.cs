using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2OSync.D2i;
using D2OSync.Database;
using D2OSync.Datacenter;

namespace D2OSync.Models
{
    public class BreedModel
    {
        public int Id { get; set; }
        public string MaleLook { get; set; }
        public string FemaleLook { get; set; }
        public string Strength { get; set; }
        public string Intelligence { get; set; }
        public string Chance { get; set; }
        public string Agility { get; set; }
        public string Wisdom { get; set; }
        public string Vitality { get; set; }
        public string BreedSpellsId { get; set; }
        public int SpawnMap { get; set; }

        public string Query { get; set; }

        private Breed Breed { get; }

        public BreedModel(Breed breed)
        {
            Breed = breed;
            SetBreed();
        }

        private void SetBreed()
        {
            Id = Breed.Id;
            MaleLook = Breed.MaleLook;
            FemaleLook = Breed.FemaleLook;

            var tempStrength = Breed.StatsPointsForStrength
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempStrength.Length - 1; i += 2)
                Strength += tempStrength[i] + "," + tempStrength[i + 1] + "|";

            var tempAgility = Breed.StatsPointsForAgility
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempAgility.Length - 1; i += 2)
                Agility += tempAgility[i] + "," + tempAgility[i + 1] + "|";

            var tempChance = Breed.StatsPointsForChance
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempChance.Length - 1; i += 2)
                Chance += tempChance[i] + "," + tempChance[i + 1] + "|";

            var tempIntell = Breed.StatsPointsForIntelligence
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempIntell.Length - 1; i += 2)
                Intelligence += tempIntell[i] + "," + tempIntell[i + 1] + "|";

            var tempVita = Breed.StatsPointsForVitality
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempVita.Length - 1; i += 2)
                Vitality += tempVita[i] + "," + tempVita[i + 1] + "|";

            var tempWisdom = Breed.StatsPointsForWisdom
                .Aggregate(string.Empty, (current, s) => s.Aggregate(current, (current2, p) => current2 + (p + ",")))
                .Split(',');
            for (var i = 0; i < tempWisdom.Length - 1; i += 2)
                Wisdom += tempWisdom[i] + "," + tempWisdom[i + 1] + "|";

            BreedSpellsId = string.Join(",", Breed.BreedSpellsId);
            SpawnMap = (int) Breed.SpawnMap;

            Console.WriteLine($"Breed {FastD2IReader.Instance.GetText(Breed.ShortNameId)} parsed.");

            GenerateQuery();
        }

        private void GenerateQuery()
        {
            Query =
                $"INSERT INTO breeds SET Id = '{Id}', MaleLook = '{MaleLook}', FemaleLook = '{FemaleLook}', StatsPointsForStrength = '{Strength}', StatsPointsForIntelligence = '{Intelligence}'," +
                $" StatsPointsForChance = '{Chance}', StatsPointsForAgility = '{Agility}', StatsPointsForVitality = '{Vitality}', StatsPointsForWisdom = '{Wisdom}', BreedSpellsId = '{BreedSpellsId}'," +
                $" SpawnMap = '{SpawnMap}';";

            DatabaseManager.ExecuteNonQuery(Query);
            Console.WriteLine(@"Added to sql");
        }

    }
}
