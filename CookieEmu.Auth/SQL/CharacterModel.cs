using System.Data.Entity;

namespace CookieEmu.Auth.SQL
{
    public partial class CharacterModel : DbContext
    {
        public CharacterModel() : base("name=CharacterModel") { }

        public virtual DbSet<Character> characters { get; set; }
    }
}
