namespace CookieEmu.Game.SQL.Monster
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MonsterModel : DbContext
    {
        public MonsterModel()
            : base("name=MonsterModel")
        {
        }

        public virtual DbSet<monsters> monsters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<monsters>()
                .Property(e => e.AllIdolsDisabled)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.CanBePushed)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.CanPlay)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.CanSwitchPos)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.CanTackle)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.DareAvailable)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.IncompatibleChallenges)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.IncompatibleIdols)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.IsBoss)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.IsMiniBoss)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.IsQuestMonster)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.Look)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.Spells)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.Subareas)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.UseBombSlot)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Property(e => e.UseSummonSlot)
                .IsUnicode(false);

            modelBuilder.Entity<monsters>()
                .Ignore(e => e.SubAreaId);
        }
    }
}
