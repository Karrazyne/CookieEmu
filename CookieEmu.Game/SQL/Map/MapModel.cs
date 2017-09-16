using System.Data.Entity;

namespace CookieEmu.Game.SQL.Map
{
    public partial class MapModel : DbContext
    {
        public MapModel() : base("name=MapModel")
        {

        }

        public virtual DbSet<Map> maps { get; set; }
    }
}
