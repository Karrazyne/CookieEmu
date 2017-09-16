using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieEmu.Game.SQL.Account
{
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
        
        public List<Character.Character> Characters { get; set; }

    }
}
