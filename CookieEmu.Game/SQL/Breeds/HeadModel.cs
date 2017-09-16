using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Game.SQL.Breeds
{
    public class HeadModel : DbContext
    {
        public HeadModel() : base("name=HeadModel") { }

        public virtual DbSet<Head> heads { get; set; }
    }
}
