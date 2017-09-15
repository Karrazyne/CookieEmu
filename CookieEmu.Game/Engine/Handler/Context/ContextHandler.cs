using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
using CookieEmu.API.Protocol.Network.Types.Game.Look;
using CookieEmu.Common;
using CookieEmu.Game.Network;

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
            client.SendAsync(new CurrentMapMessage(84674563, MapKey));
            client.SendAsync(new BasicTimeMessage(Functions.ReturnUnixTimeStamp(DateTime.Now), 60));
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
            client.SendAsync(new MapComplementaryInformationsDataMessage(278, 84674563, new List<HouseInformations>(),
                new List<GameRolePlayActorInformations>()
                {
                    new GameRolePlayActorInformations
                    {
                        ContextualId = 1,
                        Disposition = new EntityDispositionInformations(380, 1),
                        Look = new EntityLook(1, new List<ushort> {90, 2146, 239, 119, 462, 590},
                            new List<int> {24986395, 42110404, 52372804, 73427089, 88826319}, new List<short> {140},
                            new List<SubEntity>())
                    }

                }, new List<InteractiveElement>(), new List<StatedElement>(),
                new List<MapObstacle>(), new List<FightCommonInformations>(), false,
                new FightStartingPositions(new List<ushort>(), new List<ushort>())));
            var toSend = new GameRolePlayShowActorMessage
            {
                Informations = new GameRolePlayActorInformations()
                {
                    ContextualId = 1,
                    Disposition = new EntityDispositionInformations(250, 1),
                    Look = new EntityLook(1, new List<ushort> {90, 2146, 239, 119, 462, 590},
                        new List<int> {24986395, 42110404, 52372804, 73427089, 88826319}, new List<short> {140},
                        new List<SubEntity>())
                }
            };
            client.SendAsync(toSend);
        }
    }
}
