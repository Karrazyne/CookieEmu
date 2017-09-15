namespace CookieEmu.Auth.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cookieemu.accounts")]
    public partial class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Login { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public string SecretQuestion { get; set; }

        [Required]
        [StringLength(255)]
        public string Nickname { get; set; }

        public void Update()
        {
            using (var context = new AccountModel())
                context.Database.ExecuteSqlCommand($"UPDATE accounts SET Nickname = '{Nickname}' WHERE Id = {Id}");
        }

        
    }
}
