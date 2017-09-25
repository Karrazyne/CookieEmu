using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Extensions;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Types.Game.Context;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay;
using CookieEmu.API.Protocol.Network.Types.Game.Look;
using CookieEmu.Common;
using CookieEmu.Game.SQL.Monster;

namespace CookieEmu.Game.Engine.Manager
{
    public class MonsterManager
    {
        public static GameRolePlayGroupMonsterInformations GetGameRolePlayGroupMonsterInformations(int subAreaId)
        {
            var m = GetMonsters(subAreaId);
            var toReturn = new GameRolePlayGroupMonsterInformations();
            if (m.Count < 1) return toReturn;

            var random = new AsyncRandom();

            var contextualId = InteractiveManager.NextUid();
            var randomIdMob = random.NextDouble(0, m.Count);
            var tempLook = m[(int) randomIdMob].Look.Replace("{", "").Replace("}", "").Split('|');

            var bonesId = ushort.Parse(tempLook[0]);
            var skins = new List<ushort>();
            var scales = new List<short>();

            switch (tempLook.Length)
            {
                case 2:
                    skins.Add(ushort.Parse(tempLook[1]));
                    break;
                case 4:
                    scales.Add(short.Parse(tempLook[3]));
                    break;
            }

            var cell = (short)random.NextDouble(0, 560);

            var monster = new GameRolePlayGroupMonsterInformations
            {
                ContextualId = contextualId,
                Look = new EntityLook(bonesId, skins, new List<int>(), scales, new List<SubEntity>()),
                Disposition = new EntityDispositionInformations(cell, 1),
                CreationTime = Functions.ReturnUnixTimeStamp(DateTime.Now),
                AgeBonusRate = 1800000,
                LootShare = -1,
                KeyRingBonus = false,
                HasAVARewardToken = false,
                HasHardcoreDrop = false,
                AlignmentSide = (sbyte)AlignmentSideEnum.ALIGNMENT_NEUTRAL,
            };
            var monsterToAdd = new List<MonsterInGroupInformations>();
            var randomMobCount = random.Next(0, 7);

            for (var j = 0; j < randomMobCount; j++)
            {
                var tempMob = random.Next(0, m.Count);
                var tempLook2 = m[tempMob].Look.Replace("{", "").Replace("}", "").Split('|');

                var bonesId2 = ushort.Parse(tempLook2[0]);
                var skins2 = new List<ushort>();
                var scales2 = new List<short>();

                switch (tempLook2.Length)
                {
                    case 2:
                        skins2.Add(ushort.Parse(tempLook[1]));
                        break;
                    case 3:
                        scales2.Add(short.Parse(tempLook[3]));
                        break;
                }

                var tempTempMob = tempMob == 0 ? 0 : tempMob - 1;
                var toAdd = new MonsterInGroupInformations
                {
                    CreatureGenericId = m[tempTempMob].Id,
                    Grade = 1,
                    Look = new EntityLook(bonesId2, skins2, new List<int>(), scales2, new List<SubEntity>())
                };
                monsterToAdd.Add(toAdd);
            }
            monster.StaticInfos = new GroupMonsterStaticInformations
            {
                MainCreatureLightInfos = new MonsterInGroupLightInformations
                {
                    Grade = 1,
                    CreatureGenericId = m[(int)randomIdMob].Id
                }, 
                Underlings = monsterToAdd
            };

            return monster;
        }

        public static List<monsters> GetMonsters(int subAreaId)
        {
            List<monsters> monsters;
            using (var model = new MonsterModel())
            {
                monsters = (from m in model.monsters
                    select m).ToList();
            }

            return monsters.Where(m => m.SubAreaId.Contains(subAreaId) && m.IsBoss == "false" && m.IsMiniBoss == "false").ToList();
        }
    }
}
