using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay;
using CookieEmu.Common;
using CookieEmu.Game.Network;
using CookieEmu.Game.SQL.Map;

namespace CookieEmu.Game.Engine.Manager
{
    public class MapManager
    {
        private static readonly Dictionary<int, Game.Maps.Map> MapInstance = new Dictionary<int, Game.Maps.Map>();

        public static void ChangeMap(Client client, int newMap)
        {
            client.SendAsync(new CurrentMapMessage(newMap, "649ae451ca33ec53bbcbcc33becf15f4"));
            client.SendAsync(new BasicTimeMessage(Functions.ReturnUnixTimeStamp(DateTime.Now), 120));
            client.CurrentMap?.RemoveClient(client);
            if (!MapInstance.ContainsKey(newMap))
            {
                MapInstance[newMap] = new Game.Maps.Map();
                MapInstance[newMap].SetMap(GetMap(newMap));
            }

            client.CurrentMap = MapInstance[newMap];
            client.CurrentMap.AddClient(client);
            client.Character.MapId = client.CurrentMap.Id;

        }

        public static Map GetMap(int mapId)
        {
            using (var context = new MapModel())
            {
                return (from m in context.maps
                    where m.MapId == mapId
                    select m).ToList().FirstOrDefault();
            }
        }

        public static List<GameRolePlayActorInformations> GetActorInformationses(int mapId)
        {
            var toRet = new List<GameRolePlayActorInformations>();
            if (!MapInstance.ContainsKey(mapId))
                return toRet;
            return MapInstance[mapId].GetGameRolePlayActorInformationses();
        }
    }
}
