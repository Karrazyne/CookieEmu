using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CookieEmu.Game.SQL.Breeds
{
    [Table("cookieemu.breeds")]
    public partial class Breed
    {
        public int Id { get; set; }

        [Required]
        public string MaleLook { get; set; }

        [Required]
        public string FemaleLook { get; set; }

        [Required]
        public string StatsPointsForStrength { get; set; }

        [Required]
        public string StatsPointsForIntelligence { get; set; }

        [Required]
        public string StatsPointsForChance { get; set; }

        [Required]
        public string StatsPointsForAgility { get; set; }

        [Required]
        [StringLength(255)]
        public string StatsPointsForVitality { get; set; }

        [Required]
        [StringLength(255)]
        public string StatsPointsForWisdom { get; set; }

        [Required]
        [StringLength(255)]
        public string BreedSpellsId { get; set; }

        [Required]
        public int SpawnMap { get; set; }

        public static Breed GetBreed(int id)
        {
            using (var context = new BreedModel())
            {
                var breed = (from b in context.breeds
                    where b.Id == id
                    select b).ToList().FirstOrDefault();
                return breed;
            }
        }
    }
}
