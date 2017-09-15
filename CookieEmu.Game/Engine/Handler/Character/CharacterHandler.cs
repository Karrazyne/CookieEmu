using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Messages.Game.Achievement;
using CookieEmu.API.Protocol.Network.Messages.Game.Almanach;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Game.Character.Choice;
using CookieEmu.API.Protocol.Network.Messages.Game.Character.Stats;
using CookieEmu.API.Protocol.Network.Messages.Game.Chat.Channel;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag;
using CookieEmu.API.Protocol.Network.Messages.Game.Dare;
using CookieEmu.API.Protocol.Network.Messages.Game.Friend;
using CookieEmu.API.Protocol.Network.Messages.Game.Idol;
using CookieEmu.API.Protocol.Network.Messages.Game.Initialization;
using CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Items;
using CookieEmu.API.Protocol.Network.Messages.Game.Inventory.Spells;
using CookieEmu.API.Protocol.Network.Messages.Game.Prism;
using CookieEmu.API.Protocol.Network.Messages.Game.Pvp;
using CookieEmu.API.Protocol.Network.Messages.Game.Shortcut;
using CookieEmu.API.Protocol.Network.Types.Game.Achievement;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Choice;
using CookieEmu.API.Protocol.Network.Types.Game.Dare;
using CookieEmu.API.Protocol.Network.Types.Game.Data.Items;
using CookieEmu.API.Protocol.Network.Types.Game.Idol;
using CookieEmu.API.Protocol.Network.Types.Game.Look;
using CookieEmu.API.Protocol.Network.Types.Game.Prism;
using CookieEmu.API.Protocol.Network.Types.Game.Shortcut;
using CookieEmu.Game.Network;

namespace CookieEmu.Game.Engine.Handler.Character
{
    public class CharacterHandler
    {
        [MessageHandler(typeof(CharactersListRequestMessage))]
        public static void HandleCharactersListRequestMessage(CharactersListRequestMessage message, Client client)
        {
            var tempmessage = new CharactersListMessage(false)
            {
                Characters = new List<CharacterBaseInformations>
                {
                    new CharacterBaseInformations(9, false)
                    {
                        Name = "CookieEmu",
                        Level = 200,
                        ObjectId = 1,
                        EntityLook = new EntityLook(1, new List<ushort> {90, 2146, 239, 119, 462, 590},
                            new List<int> {24986395, 42110404, 52372804, 73427089, 88826319}, new List<short> {140},
                            new List<SubEntity>())
                    }
                }
            };
            client.SendAsync(tempmessage);
        }

        [MessageHandler(typeof(CharacterSelectionMessage))]
        public static void HandleCharacterSelectionMessage(CharacterSelectionMessage message, Client client)
        {
            client.SendAsync(new CharacterSelectedSuccessMessage(new CharacterBaseInformations(9, false)
            {
                Name = "CookieEmu",
                Level = 200,
                ObjectId = 1,
                EntityLook = new EntityLook(1, new List<ushort> { 90, 2146, 239, 119, 462, 590 },
                    new List<int> { 24986395, 42110404, 52372804, 73427089, 88826319 }, new List<short> { 140 },
                    new List<SubEntity>())
            }, true));
            client.SendAsync(new InventoryContentMessage(new List<ObjectItem>(), 0));
            client.SendAsync(new ShortcutBarContentMessage(0, new List<Shortcut>()));
            client.SendAsync(new ShortcutBarContentMessage(1, new List<Shortcut>()));
            client.SendAsync(new RoomAvailableUpdateMessage(0));
            client.SendAsync(new HavenBagPackListMessage(new List<sbyte>()));
            client.SendAsync(new EmoteListMessage(new List<byte>()));
            client.SendAsync(new AlignmentRankUpdateMessage((byte)AlignmentSideEnum.ALIGNMENT_NEUTRAL, false));
            client.SendAsync(new DareCreatedListMessage(new List<DareInformations>(), new List<DareVersatileInformations>()));
            client.SendAsync(new DareSubscribedListMessage(new List<DareInformations>(), new List<DareVersatileInformations>()));
            client.SendAsync(new DareWonListMessage(new List<double>()));
            client.SendAsync(new DareRewardsListMessage(new List<DareReward>()));
            client.SendAsync(new PrismsListMessage(new List<PrismSubareaEmptyInfo>()));
            client.SendAsync(new EnabledChannelsMessage(new List<byte>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13 }, new  List<byte>()));
            client.SendAsync(new SpellListMessage(true, new List<SpellItem>()));
            client.SendAsync(new ShortcutBarContentMessage(1, new List<Shortcut>()));
            client.SendAsync(new InventoryWeightMessage(137, 2252));
            client.SendAsync(new FriendWarnOnConnectionStateMessage(true));
            client.SendAsync(new FriendGuildWarnOnAchievementCompleteStateMessage(true));
            client.SendAsync(new WarnOnPermaDeathStateMessage(true));
            client.SendAsync(new GuildMemberWarnOnConnectionStateMessage(true));
            client.SendAsync(new SequenceNumberRequestMessage());
            client.SendAsync(new SpouseStatusMessage(false));
            client.SendAsync(new AchievementListMessage(new List<ushort>(), new List<AchievementRewardable>()));
            client.SendAsync(new CharacterCapabilitiesMessage(4095));
            client.SendAsync(new AlmanachCalendarDateMessage(91));
            client.SendAsync(new IdolListMessage(new List<ushort>(), new List<ushort>(), new List<PartyIdol>()));
            client.SendAsync(new CharacterExperienceGainMessage(0, 0, 0, 0));
            client.SendAsync(new CharacterLoadingCompleteMessage());
        }
    }
}
