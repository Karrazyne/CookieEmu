using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Game.SQL.Interactive
{
    [Table("map_interactives")]
    public class Interactive
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public int SkillId { get; set; }
        public int MapId { get; set; }
        public int CellId { get; set; }
    }
}
