using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieEmu.Game.SQL.Cosmetic
{
    [Table("cookieemu.titles")]
    public partial class titles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public int? NameFemaleId { get; set; }

        public int? NameMaleId { get; set; }

        public int? Visible { get; set; }

        [StringLength(9999)]
        public string TextFemale { get; set; }

        [StringLength(9999)]
        public string TextMale { get; set; }
    }
}
