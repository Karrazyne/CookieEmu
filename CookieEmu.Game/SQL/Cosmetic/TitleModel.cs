using System.Data.Entity;

namespace CookieEmu.Game.SQL.Cosmetic
{
    public partial class TitleModel : DbContext
    {
        public TitleModel()
            : base("name=TitleModel")
        {
        }

        public virtual DbSet<titles> titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<titles>()
                .Property(e => e.TextFemale)
                .IsUnicode(false);

            modelBuilder.Entity<titles>()
                .Property(e => e.TextMale)
                .IsUnicode(false);
        }
    }
}
