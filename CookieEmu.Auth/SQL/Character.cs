using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieEmu.Auth.SQL
{
    [Table("cookieemu.characters")]
    public partial class Character
    {
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public double Experience { get; set; }

        [Required]
        public byte Breed { get; set; }

        [Required]
        [StringLength(500)]
        public string EntityLookString { get; set; }

        [Required]
        public byte Sex { get; set; }

        [Required]
        public int MapId { get; set; }

        [Required]
        public short CellId { get; set; }

        [Required]
        public byte Direction { get; set; }
    }
}
