using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookieEmu.Game.SQL.Map
{
    [Table("cookieemu.world_maps")]
    public partial class Map
    {
        public int MapId { get; set; }
        
        [Required]
        public int RelativeId { get; set; }

        [Required]
        public int SubAreaId { get; set; }

        [Required]
        public int TopNeighbourId { get; set; }

        [Required]
        public int BottomNeighbourId { get; set; }

        [Required]
        public int LeftNeighbourId { get; set; }

        [Required]
        public int RightNeighbourId { get; set; }

        [Required]
        public string BluePlacement { get; set; }

        [Required]
        public string RedPlacement { get; set; }
    }
}
