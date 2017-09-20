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
using CookieEmu.API.Protocol.Network.Messages.Game.Chat.Community;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Job;
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
using CookieEmu.API.Protocol.Network.Messages.Game.Startup;
using CookieEmu.API.Protocol.Network.Messages.Web.Ankabox;
using CookieEmu.API.Protocol.Network.Types.Game.Achievement;
using CookieEmu.API.Protocol.Network.Types.Game.Character.Choice;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using CookieEmu.API.Protocol.Network.Types.Game.Dare;
using CookieEmu.API.Protocol.Network.Types.Game.Data.Items;
using CookieEmu.API.Protocol.Network.Types.Game.House;
using CookieEmu.API.Protocol.Network.Types.Game.Idol;
using CookieEmu.API.Protocol.Network.Types.Game.Interactive.Skill;
using CookieEmu.API.Protocol.Network.Types.Game.Prism;
using CookieEmu.API.Protocol.Network.Types.Game.Shortcut;
using CookieEmu.API.Protocol.Network.Types.Game.Startup;
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
                Sex = t.Sex == 0
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
            client.SendAsync(new RoomAvailableUpdateMessage(1));
            client.SendAsync(new HavenBagPackListMessage(new List<sbyte>()));
            client.SendAsync(new EmoteListMessage(new List<byte>()));

            #region Job Packets
            client.SendAsync(new JobDescriptionMessage(new List<JobDescription>
            {
                new JobDescription(36, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCollect
                    {
                        Min = 1,
                        Max = 7,
                        Time = 30,
                        SkillId = 124
                    },
                    new SkillActionDescriptionCollect
                    {
                        Min = 1,
                        Max = 1,
                        Time = 30,
                        SkillId = 301
                    },
                    new SkillActionDescriptionCraft
                    {
                        Probability = 100,
                        SkillId = 135
                    }
                }),
                new JobDescription(11, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 20,
                        Probability = 100
                    }
                }),
                new JobDescription(65, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 171,
                        Probability = 100
                    }
                }),
                new JobDescription(15, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 13,
                        Probability = 100
                    }
                }),
                new JobDescription(26, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 300,
                        Max = 1,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 68,
                        Max = 7,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 23,
                        Probability = 100
                    }
                }),
                new JobDescription(62, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 164,
                        Probability = 5
                    }
                }),
                new JobDescription(48, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 118,
                        Probability = 5
                    }
                }),
                new JobDescription(41, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 134,
                        Probability = 100
                    }
                }),
                new JobDescription(16, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 12,
                        Probability = 100
                    }
                }),
                new JobDescription(27, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 63,
                        Probability = 100
                    }
                }),
                new JobDescription(2, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 6,
                        Max = 7,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 101,
                        Probability = 100
                    },
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 299,
                        Max = 1,
                        Time = 30,
                        Min = 1
                    }
                }),
                new JobDescription(63, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 169,
                        Probability = 5
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 168,
                        Probability = 5
                    }
                }),
                new JobDescription(13, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 15,
                        Probability = 100
                    }
                }),
                new JobDescription(74, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 351,
                        Probability = 5
                    }
                }),
                new JobDescription(24, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 24,
                        Max = 7,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 48,
                        Probability = 100
                    },
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 298,
                        Max = 1,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 32,
                        Probability = 100
                    }
                }),
                new JobDescription(28, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 109,
                        Probability = 100
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 27,
                        Probability = 100
                    },
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 45,
                        Max = 7,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 122,
                        Probability = 100
                    },
                    new SkillActionDescriptionCollect
                    {
                        SkillId = 296,
                        Max = 1,
                        Time = 30,
                        Min = 1
                    },
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 47,
                        Probability = 100
                    }
                }),
                new JobDescription(44, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 113,
                        Probability = 5
                    }
                }),
                new JobDescription(64, new List<SkillActionDescription>
                {
                    new SkillActionDescriptionCraft
                    {
                        SkillId = 166,
                        Probability = 5
                    }
                })
            }));
            client.SendAsync(new JobExperienceMultiUpdateMessage(new List<JobExperience>
            {
                new JobExperience(36, 1, 0, 0, 20),
                new JobExperience(11, 1, 0, 0, 20),
                new JobExperience(65, 1, 0, 0, 20),
                new JobExperience(15, 1, 0, 0, 20),
                new JobExperience(26, 1, 0, 0, 20),
                new JobExperience(62, 1, 0, 0, 20),
                new JobExperience(48, 1, 0, 0, 20),
                new JobExperience(41, 1, 0, 0, 20),
                new JobExperience(16, 1, 0, 0, 20),
                new JobExperience(27, 1, 0, 0, 20),
                new JobExperience(2, 1, 0, 0, 20),
                new JobExperience(63, 1, 0, 0, 20),
                new JobExperience(13, 1, 0, 0, 20),
                new JobExperience(74, 1, 0, 0, 20),
                new JobExperience(24, 1, 0, 0, 20),
                new JobExperience(60, 1, 0, 0, 20),
                new JobExperience(28, 1, 0, 0, 20),
                new JobExperience(44, 1, 0, 0, 20),
                new JobExperience(64, 1, 0, 0, 20),
            }));
            client.SendAsync(new JobCrafterDirectorySettingsMessage(new List<JobCrafterDirectorySettings>
            {
                new JobCrafterDirectorySettings(36, 0, true),
                new JobCrafterDirectorySettings(11, 0, true),
                new JobCrafterDirectorySettings(65, 0, true),
                new JobCrafterDirectorySettings(15, 0, true),
                new JobCrafterDirectorySettings(26, 0, true),
                new JobCrafterDirectorySettings(62, 0, true),
                new JobCrafterDirectorySettings(48, 0, true),
                new JobCrafterDirectorySettings(41, 0, true),
                new JobCrafterDirectorySettings(16, 0, true),
                new JobCrafterDirectorySettings(27, 0, true),
                new JobCrafterDirectorySettings(2, 0, true),
                new JobCrafterDirectorySettings(63, 0, true),
                new JobCrafterDirectorySettings(13, 0, true),
                new JobCrafterDirectorySettings(74, 0, true),
                new JobCrafterDirectorySettings(24, 0, true),
                new JobCrafterDirectorySettings(60, 0, true),
                new JobCrafterDirectorySettings(28, 0, true),
                new JobCrafterDirectorySettings(44, 0, true),
                new JobCrafterDirectorySettings(64, 0, true),
            }));
            #endregion
            
            client.SendAsync(new AlignmentRankUpdateMessage((byte)AlignmentSideEnum.ALIGNMENT_NEUTRAL, false));
            client.SendAsync(new DareCreatedListMessage(new List<DareInformations>(), new List<DareVersatileInformations>()));
            client.SendAsync(new DareSubscribedListMessage(new List<DareInformations>(), new List<DareVersatileInformations>()));
            client.SendAsync(new DareWonListMessage(new List<double>()));
            client.SendAsync(new DareRewardsListMessage(new List<DareReward>()));
            client.SendAsync(new PrismsListMessage(new List<PrismSubareaEmptyInfo>()));
            client.SendAsync(new EnabledChannelsMessage(new List<byte>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13 }, new List<byte>()));
            client.SendAsync(new ChatCommunityChannelCommunityMessage(0));
            client.SendAsync(new SpellListMessage(true, new List<SpellItem>()));
            client.SendAsync(new ShortcutBarContentMessage(1, new List<Shortcut>()));
            client.SendAsync(new InventoryWeightMessage(0, 1000));
            client.SendAsync(new FriendWarnOnConnectionStateMessage(true));
            client.SendAsync(new FriendWarnOnLevelGainStateMessage(true));
            client.SendAsync(new FriendGuildWarnOnAchievementCompleteStateMessage(true));
            client.SendAsync(new WarnOnPermaDeathStateMessage(true));
            client.SendAsync(new GuildMemberWarnOnConnectionStateMessage(true));
            client.SendAsync(new SequenceNumberRequestMessage());
            client.SendAsync(new TextInformationMessage(1, 89, new List<string>()));
            client.SendAsync(new OnConnectionEventMessage(3));
            client.SendAsync(new ServerExperienceModificatorMessage(200));
            client.SendAsync(new SpouseStatusMessage(false));
            client.SendAsync(new AchievementListMessage(new List<ushort>(), new List<AchievementRewardable>()));
            client.SendAsync(new CharacterCapabilitiesMessage(4095));
            client.SendAsync(new AlmanachCalendarDateMessage(5));
            client.SendAsync(new IdolListMessage(new List<ushort>(), new List<ushort>(), new List<PartyIdol>()));
            client.SendAsync(new CharacterExperienceGainMessage(0, 0, 0, 0));
            client.SendAsync(new MailStatusMessage(0, 0));
            client.SendAsync(new AccountHouseMessage(new List<AccountHouseInformations>()));
            client.SendAsync(new CharacterLoadingCompleteMessage());
            client.SendAsync(new StartupActionsListMessage(new List<StartupActionAddObject>()));
        }
    }
}
