using System.Data.Entity;

namespace CookieEmu.Game.SQL.Account
{
    public partial class AccountModel : DbContext
    {
        public AccountModel()
            : base("name=AccountModel")
        {
        }

        public virtual DbSet<Account> accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Ticket)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.SecretQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Nickname)
                .IsUnicode(false);
        }
    }
}
