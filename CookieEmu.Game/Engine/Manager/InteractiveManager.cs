using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Extensions;
using CookieEmu.API.Protocol.Network.Types.Game.Interactive;
using CookieEmu.Game.SQL.Interactive;

namespace CookieEmu.Game.Engine.Manager
{
    public class InteractiveManager
    {
        private static readonly List<int> Uid = new List<int>();
        private static readonly AsyncRandom Random = new AsyncRandom(45454);

        public static List<InteractiveElement> GetInteractives(int mapId)
        {
            List<Interactive> interactives;
            using (var context = new InteractiveModel())
            {
                interactives = (from i in context.interactives
                    where i.MapId == mapId
                    select i).ToList();
            }
            if (interactives.Count > 0)
            {
                var tempList = new List<InteractiveElement>();
                foreach (var elem in interactives)
                {
                    tempList.Add(new InteractiveElementWithAgeBonus
                    {
                        ElementId = elem.ElementId,
                        ElementTypeId = elem.ElementTypeId,
                        AgeBonus = 200,
                        DisabledSkills = new List<InteractiveElementSkill>(),
                        EnabledSkills = new List<InteractiveElementSkill> { new InteractiveElementSkill((uint) elem.SkillId, NextUid())},
                        OnCurrentMap = true
                    });
                }
                return tempList;
            }
            return new List<InteractiveElement>();
        }

        public static List<StatedElement> GetStatedElements(int mapId)
        {
            List<Interactive> stated;
            using (var context = new InteractiveModel())
            {
                stated = (from s in context.interactives
                    where s.MapId == mapId
                    select s).ToList();
            }

            return stated.Count > 0
                ? stated.Select(i => new StatedElement(i.ElementId, (ushort) i.CellId, 0, true)).ToList()
                : new List<StatedElement>();
        }

        public static int NextUid()
        {
            int id;
            if (Uid.Count == 0)
            {
                id = (int) Random.NextDouble(10000, 99999);
                Uid.Add(id);
                return id;
            }

            id = (int)Random.NextDouble(10000, 99999);
            while(Uid.Contains(id))
                id = (int)Random.NextDouble(10000, 99999);
            Uid.Add(id);
            return id;
        }
    }
}
