namespace CookieEmu.Auth.SQL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(255)]
        public string Ticket { get; set; }

        [Required]
        public string SecretQuestion { get; set; }

        [Required]
        [StringLength(255)]
        public string Nickname { get; set; }

        public void UpdateNickname()
        {
            using (var context = new AccountModel())
                context.Database.ExecuteSqlCommand($"UPDATE accounts SET Nickname = '{Nickname}' WHERE Id = {Id}");
        }

        public void UpdateTicket()
        {
            using (var context = new AccountModel())
                context.Database.ExecuteSqlCommand($"UPDATE accounts SET Ticket = '{Ticket}' WHERE Id = {Id}");
        }

        
    }
}
