using System.Linq;

namespace CookieEmu.Game.SQL.Monster
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cookieemu.monsters")]
    public partial class monsters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string AllIdolsDisabled { get; set; }

        [StringLength(255)]
        public string CanBePushed { get; set; }

        [StringLength(255)]
        public string CanPlay { get; set; }

        [StringLength(255)]
        public string CanSwitchPos { get; set; }

        [StringLength(255)]
        public string CanTackle { get; set; }

        public int? CorrespondingMiniBossId { get; set; }

        public int? CreatureBoneId { get; set; }

        [StringLength(255)]
        public string DareAvailable { get; set; }

        public int? FavoriteSubareaId { get; set; }

        public int? GfxId { get; set; }

        [StringLength(255)]
        public string IncompatibleChallenges { get; set; }

        [StringLength(255)]
        public string IncompatibleIdols { get; set; }

        [StringLength(255)]
        public string IsBoss { get; set; }

        [StringLength(255)]
        public string IsMiniBoss { get; set; }

        [StringLength(255)]
        public string IsQuestMonster { get; set; }

        [StringLength(255)]
        public string Look { get; set; }

        public int? NameId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? Race { get; set; }

        [StringLength(255)]
        public string Spells { get; set; }

        [StringLength(255)]
        public string Subareas { get; set; }

        [StringLength(255)]
        public string UseBombSlot { get; set; }

        [StringLength(255)]
        public string UseSummonSlot { get; set; }

        
        public List<int> SubAreaId => Subareas.Length < 1 ? new List<int>() : Subareas.Split(',').Select(int.Parse).ToList();
    }
}
