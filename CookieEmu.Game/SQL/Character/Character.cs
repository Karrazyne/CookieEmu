using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Game.SQL.Character
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

        public Character() { }

        public Character(int accountId, string name, byte level, double exp, byte breed, string entityLook, bool sex,
            int mapid, short cellid, byte direction)
        {
            OwnerId = accountId;
            Name = name;
            Level = level;
            Experience = exp;
            Breed = breed;
            EntityLookString = entityLook;
            Sex = (byte) (!sex ? 1 : 0);
            MapId = mapid;
            CellId = cellid;
            Direction = direction;
        }

        public void Create()
        {
            
        }
    }
}
