using System;
using System.Collections.Generic;
using System.Linq;
using CookieEmu.API.Pathfinding;
using CookieEmu.API.Pathfinding.Positions;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Game.Character.Stats;
using CookieEmu.API.Protocol.Network.Messages.Game.Context;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Alignment;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Characteristic;
using CookieEmu.API.Protocol.Network.Types.Game.Context;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Fight;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay;
using CookieEmu.API.Protocol.Network.Types.Game.House;
using CookieEmu.API.Protocol.Network.Types.Game.Interactive;
using CookieEmu.Common;
using CookieEmu.Game.Engine.Manager;
using CookieEmu.Game.Network;
using CookieEmu.Game.Utils;

namespace CookieEmu.Game.Engine.Handler.Context
{
    public class ContextHandler
    {
        public static string MapKey = "649ae451ca33ec53bbcbcc33becf15f4";

        [MessageHandler(typeof(GameContextCreateRequestMessage))]
        public static void HandleGameContextCreateRequestMessage(GameContextCreateRequestMessage message, Client client)
        {
            client.SendAsync(new GameContextDestroyMessage());
            client.SendAsync(new GameContextCreateMessage((byte)GameContextEnum.ROLE_PLAY));
            client.SendAsync(new LifePointsRegenBeginMessage(5));
            MapManager.ChangeMap(client, client.Character.MapId);
            //client.SendAsync(new CurrentMapMessage(client.Character.MapId, MapKey));
            
            client.SendAsync(new CharacterStatsListMessage(new CharacterCharacteristicsInformations(1, 2, 3, 4,
                1000000000, 0, 0, 0, new ActorExtendedAlignmentInformations(0, 0, 0, 0), 5000, 5000, 10000, 10000, 12,
                6, new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1), 1,
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new CharacterBaseCharacteristic(1, 1, 1, 1, 1),
                new CharacterBaseCharacteristic(1, 1, 1, 1, 1), new List<CharacterSpellModification>(), 0)));
            
        }

        [MessageHandler(typeof(MapInformationsRequestMessage))]
        public static void HandleMapInformationsRequestMessage(MapInformationsRequestMessage message, Client client)
        {
            client.Character.MapId = message.MapId;
            client.SendAsync(new MapComplementaryInformationsDataMessage((ushort) client.CurrentMap.SubAreaId,
                message.MapId, new List<HouseInformations>(), client.CurrentMap.GetGameRolePlayActorInformationses(), 
                InteractiveManager.GetInteractives(message.MapId), InteractiveManager.GetStatedElements(message.MapId),
                new List<MapObstacle>(), new List<FightCommonInformations>(), false,
                new FightStartingPositions(client.CurrentMap.BluePlacement, client.CurrentMap.RedPlacement)));

        }

        [MessageHandler(typeof(GameMapMovementRequestMessage))]
        public static void HandleGameMapMovementRequestMessage(GameMapMovementRequestMessage message, Client client)
        {
            client.Character.CellId = (short) (message.KeyMovements.Last() & 4095);
            client.Character.Direction = (byte) (message.KeyMovements.Last() >> 12);
            var movements = from key in message.KeyMovements
                let cellId = key & 4095
                select cellId;
            client.CurrentMap.Send(new GameMapMovementMessage(movements.Select(x => (short)x).ToList(), client.Character.Direction, client.Character.Id));
            client.CurrentMap.Send(new GameContextRefreshEntityLookMessage(client.Character.Id, Helper.EntityLookBuilder(client.Character)));
            client.CurrentMap.RefreshActor();
        }

        [MessageHandler(typeof(GameMapChangeOrientationRequestMessage))]
        public static void HandleGameMapChangeOrientationRequestMessage(GameMapChangeOrientationRequestMessage message,
            Client client)
        {
            client.Character.Direction = message.Direction;
            client.CurrentMap.Send(
                new GameMapChangeOrientationMessage(new ActorOrientation(client.Character.Id, message.Direction)));
            client.CurrentMap.Send(new GameContextRefreshEntityLookMessage(client.Character.Id,
                Helper.EntityLookBuilder(client.Character)));
            client.CurrentMap.RefreshActor();
        }

        [MessageHandler(typeof(ChangeMapMessage))]
        public static void HandleChangeMapMessage(ChangeMapMessage message, Client client)
        {
            var cell = client.Character.CellId;
            if (client.CurrentMap.TopNeighbourId == message.MapId)
                cell += 532;
            if (client.CurrentMap.BottomNeighbourId == message.MapId)
                cell -= 532;
            if (client.CurrentMap.LeftNeighbourId == message.MapId)
                cell += 13;
            if (client.CurrentMap.RightNeighbourId == message.MapId)
                cell -= 13;

            if (cell != client.Character.CellId)
            {
                client.Character.CellId = cell;
                MapManager.ChangeMap(client, message.MapId);
            }
        }

        [MessageHandler(typeof(GameMapMovementCancelMessage))]
        public static void HandleGameMapMovementCancelMessage(GameMapMovementCancelMessage message, Client client)
        {
            client.SendAsync(new BasicNoOperationMessage());
        }
    }
}
