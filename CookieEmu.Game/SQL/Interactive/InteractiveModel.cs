using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.Game.SQL.Breeds;

namespace CookieEmu.Game.SQL.Interactive
{
    public partial class InteractiveModel : DbContext
    {
        public InteractiveModel() : base("name=InteractiveModel")
        {

        }

        public virtual DbSet<Interactive> interactives { get; set; }
    }
}
