namespace CookieEmu.Auth.SQL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
                .Property(e => e.SecretQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Nickname)
                .IsUnicode(false);
        }
    }
}
