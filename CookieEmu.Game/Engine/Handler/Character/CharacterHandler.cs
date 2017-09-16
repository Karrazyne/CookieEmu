using System;
using System.Collections.Generic;
using System.Linq;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Messages.Game.Achievement;
using CookieEmu.API.Protocol.Network.Messages.Game.Almanach;
using CookieEmu.API.Protocol.Network.Messages.Game.Basic;
using CookieEmu.API.Protocol.Network.Messages.Game.Character.Choice;
using CookieEmu.API.Protocol.Network.Messages.Game.Character.Creation;
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
using CookieEmu.API.Protocol.Network.Messages.Game.Script;
using CookieEmu.API.Protocol.Network.Messages.Game.Shortcut;
using CookieEmu.API.Protocol.Network.Types.Game.Achievement;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Choice;
using CookieEmu.API.Protocol.Network.Types.Game.Dare;
using CookieEmu.API.Protocol.Network.Types.Game.Data.Items;
using CookieEmu.API.Protocol.Network.Types.Game.Idol;
using CookieEmu.API.Protocol.Network.Types.Game.Prism;
using CookieEmu.API.Protocol.Network.Types.Game.Shortcut;
using CookieEmu.Game.Engine.Manager;
using CookieEmu.Game.Network;
using CookieEmu.Game.SQL.Breeds;
using CookieEmu.Game.Utils;

namespace CookieEmu.Game.Engine.Handler.Character
{
    public class CharacterHandler
    {
        [MessageHandler(typeof(CharactersListRequestMessage))]
        public static void HandleCharactersListRequestMessage(CharactersListRequestMessage message, Client client)
        {
            if (client.Account.Characters.Count > 0)
                SendCharacterListMessage(client);
            else
                client.SendAsync(new CharactersListMessage
                {
                    Characters = new List<CharacterBaseInformations>(),
                    HasStartupActions = false
                });
        }

        [MessageHandler(typeof(CharacterCreationRequestMessage))]
        public static void HandleCharacterCreationRequestMessage(CharacterCreationRequestMessage message, Client client)
        {
            if (client.Account.Characters.Count >= 5)
            {
                client.SendAsync(
                    new CharacterCreationResultMessage((byte) CharacterCreationResultEnum.ERR_TOO_MANY_CHARACTERS));
                return;
            }
            if (CharacterManager.NameExist(message.Name))
            {
                client.SendAsync(
                    new CharacterCreationResultMessage((byte)CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS));
                return;
            }

            CreateCharacter(client, message);
        }

        [MessageHandler(typeof(CharacterSelectionMessage))]
        public static void HandleCharacterSelectionMessage(CharacterSelectionMessage message, Client client)
        {
            SelectCharacter(client, message.ObjectId);
        }

        [MessageHandler(typeof(CharacterFirstSelectionMessage))]
        public static void HandleCharacterFirstSelectionMessage(CharacterFirstSelectionMessage message, Client client)
        {
            client.SendAsync(new CinematicMessage(10));
            SelectCharacter(client, message.ObjectId);
        }

        private static void SelectCharacter(Client client, double id)
        {
            var character = client.Account.Characters.FirstOrDefault(x => x.Id == (int) id);
            client.Character = character;
            SendLastMessage(client);
        }

        private static void SendCharacterListMessage(Client client)
        {
            client.Account.Characters = CharacterManager.ReturnCharacters(client.Account.Id);

            var cbi = new List<CharacterBaseInformations>(client.Account.Characters.Count);
            cbi.AddRange(client.Account.Characters.Select(t => new CharacterBaseInformations
            {
                Breed = (sbyte) t.Breed,
                EntityLook = Helper.EntityLookBuilder(t),
                Name = t.Name,
                Level = t.Level,
                ObjectId = (ulong) t.Id,
                Sex = t.Sex == 1
            }));
            client.SendAsync(new CharactersListMessage
            {
                Characters = cbi,
                HasStartupActions = false
            });
        }

        private static void CreateCharacter(Client client, CharacterCreationRequestMessage message)
        {
            var name = message.Name;
            var breed = Breed.GetBreed(message.Breed);
            var sex = message.Sex;
            var look = !sex ? breed.MaleLook : breed.FemaleLook;
            var colors = string.Join(",", message.Colors);
            var head = message.CosmeticId;
            var entitylook = look.Insert(look.IndexOf("}", StringComparison.Ordinal) + 1, "," + colors + "," + head);
            var character = new SQL.Character.Character(client.Account.Id, name, 1, 0, (byte)message.Breed, entitylook,
                message.Sex, breed.SpawnMap, 375, (byte) DirectionsEnum.DIRECTION_SOUTH);
            CharacterManager.CreateCharacter(character);
            client.SendAsync(new CharacterCreationResultMessage((byte)CharacterCreationResultEnum.OK));
            SendCharacterListMessage(client);
        }

        private static void SendLastMessage(Client client)
        {
            client.SendAsync(new CharacterSelectedSuccessMessage(new CharacterBaseInformations
            {
                Breed = (sbyte)client.Character.Breed,
                Level = client.Character.Level,
                EntityLook = Helper.EntityLookBuilder(client.Character),
                Name = client.Character.Name,
                ObjectId = (ulong)client.Character.Id,
                Sex = client.Character.Sex == 1

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
            client.SendAsync(new EnabledChannelsMessage(new List<byte>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13 }, new List<byte>()));
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
