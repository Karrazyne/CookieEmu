using System.Data.Entity;

namespace CookieEmu.Game.SQL.Breeds
{
    public partial class BreedModel : DbContext
    {
        public BreedModel() : base("name=BreedModel")
        {
            
        }

        public virtual DbSet<Breed> breeds { get; set; }
    }
}
