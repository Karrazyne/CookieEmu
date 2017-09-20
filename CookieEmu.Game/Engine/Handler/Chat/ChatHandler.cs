using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Messages.Game.Chat;
using CookieEmu.API.Protocol.Network.Messages.Game.Chat.Channel;
using CookieEmu.API.Protocol.Network.Messages.Game.Chat.Smiley;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote;
using CookieEmu.Common;
using CookieEmu.Game.Engine.Manager;
using CookieEmu.Game.Network;

namespace CookieEmu.Game.Engine.Handler.Chat
{
    public class ChatHandler
    {
        [MessageHandler(typeof(EmotePlayRequestMessage))]
        public static void HandleEmotePlayRequestMessage(EmotePlayRequestMessage message, Client client)
        {
            client.CurrentMap.Send(new EmotePlayMessage
            {
                AccountId = client.Account.Id,
                ActorId = client.Character.Id,
                EmoteId = message.EmoteId,
                EmoteStartTime = Functions.ReturnUnixTimeStamp(DateTime.Now)
            });
        }

        [MessageHandler(typeof(ChatSmileyRequestMessage))]
        public static void HandleChatSmileyRequestMessage(ChatSmileyRequestMessage message, Client client)
        {
            client.CurrentMap.Send(new ChatSmileyMessage(client.Character.Id, message.SmileyId, client.Account.Id));
        }

        [MessageHandler(typeof(ChatClientMultiMessage))]
        public static void HandleChatClientMultiMessage(ChatClientMultiMessage message, Client client)
        {
            if (message.Content.StartsWith("."))
            {
                var arr = message.Content.Replace(".moveto", "").Trim();
                int mapId;
                if (int.TryParse(arr, out mapId))
                {
                    MapManager.ChangeMap(client, mapId);
                }
                else
                    Console.WriteLine(message.Content);
                return;
            }
            switch ((ChatChannelsMultiEnum) message.Channel)
            {
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                {
                    client.CurrentMap.Send(new ChatServerMessage
                    {
                        Content = message.Content,
                        Channel = message.Channel,
                        Fingerprint = "",
                        SenderAccountId = client.Account.Id,
                        SenderId = client.Character.Id,
                        SenderName = client.Character.Name,
                        Timestamp = Functions.ReturnUnixTimeStamp(DateTime.Now)
                    });
                    break;
                }
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    var tempClient = GameServer.Clients.Where(clt => clt.CurrentMap.SubAreaId == client.CurrentMap.SubAreaId).ToList();
                    tempClient.ForEach(x =>
                        x.SendAsync(new ChatServerMessage
                        {
                            Channel = message.Channel,
                            Content = message.Content,
                            SenderAccountId = client.Account.Id,
                            SenderId = client.Character.Id,
                            SenderName = client.Character.Name,
                            Timestamp = Functions.ReturnUnixTimeStamp(DateTime.Now),
                            Fingerprint = ""
                        }));
                    break;
            }
        }

        [MessageHandler(typeof(ChannelEnablingMessage))]
        public static void HandleChannelEnablingMessage(ChannelEnablingMessage message, Client client)
        {
            client.SendAsync(new ChannelEnablingChangeMessage(message.Channel, message.Enable));
        }
    }
}
