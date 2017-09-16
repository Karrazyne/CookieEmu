using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Game.SQL.Character
{
    public partial class CharacterModel : DbContext
    {
        public CharacterModel() : base("name=CharacterModel") { }

        public virtual DbSet<Character> characters { get; set; }
    }
}
