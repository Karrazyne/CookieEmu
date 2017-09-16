using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Alignment;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Restriction;
using CookieEmu.API.Protocol.Network.Types.Game.Context;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay;
using CookieEmu.Game.Utils;

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

        public GameRolePlayCharacterInformations GetGameRolePlayCharacterInformations()
        {
            var toRet = new GameRolePlayCharacterInformations
            {
                Name = Name,
                Look = Helper.EntityLookBuilder(this),
                Disposition = new EntityDispositionInformations(CellId, Direction),
                ContextualId = (double) Id,
                AccountId = OwnerId,
                AlignmentInfos = new ActorExtendedAlignmentInformations
                {
                    Aggressable = 0,
                    AlignmentGrade = 0,
                    AlignmentSide = (sbyte) AlignmentSideEnum.ALIGNMENT_NEUTRAL,
                    AlignmentValue = 0,
                    CharacterPower = 0,
                    Honor = 0,
                    HonorGradeFloor = 0,
                    HonorNextGradeFloor = 0
                },
                HumanoidInfo = new HumanInformations
                {
                    Sex = Sex == 1,
                    Options = new List<HumanOption>(),
                    Restrictions = new ActorRestrictionsInformations(false, false, false, false, false, false, false, false,
                        false, false, false, false, false, false, false, false, false, false, false, false, false)
                }
            };
            return toRet;
        }
    }
}
