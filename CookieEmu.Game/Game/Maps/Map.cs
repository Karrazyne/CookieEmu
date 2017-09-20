using System.Collections.Generic;
using System.Linq;
using CookieEmu.API.Protocol;
using CookieEmu.API.Protocol.Network.Messages.Game.Context;
using CookieEmu.API.Protocol.Network.Messages.Game.Context.Roleplay;
using CookieEmu.API.Protocol.Network.Types.Game.Context.Roleplay;
using CookieEmu.Game.Engine.Manager;
using CookieEmu.Game.Network;

namespace CookieEmu.Game.Game.Maps
{
    public class Map
    {
        private SQL.Map.Map Record { get; set; }

        private readonly List<Client> _clients;

        public int Id => Record.MapId;

        public int RelativeId => Record.RelativeId;

        public int SubAreaId => Record.SubAreaId;

        public int TopNeighbourId => Record.TopNeighbourId;

        public int BottomNeighbourId => Record.BottomNeighbourId;

        public int LeftNeighbourId => Record.LeftNeighbourId;

        public int RightNeighbourId => Record.RightNeighbourId;

        public List<ushort> BluePlacement => Record.BluePlacement.Length < 1
            ? new List<ushort>()
            : Record.BluePlacement.Split(',').Select(ushort.Parse).ToList();

        public List<ushort> RedPlacement => Record.RedPlacement.Length < 1
            ? new List<ushort>()
            : Record.RedPlacement.Split(',').Select(ushort.Parse).ToList();

        public Map()
        {
            _clients = new List<Client>();
        }

        public void SetMap(SQL.Map.Map map)
        {
            Record = map;
        }

        public void AddClient(Client client)
        {
            if (_clients.Contains(client)) return;
            _clients.Add(client);
            SendGameRolePlayShowActorMessage(client);
            Send(new GameRolePlayShowActorMessage(client.Character.GetGameRolePlayCharacterInformations()));
        }

        public void RemoveClient(Client client)
        {
            if (!_clients.Contains(client)) return;
            _clients.Remove(client);
            Send(new GameContextRemoveElementMessage(client.Character.Id));
        }

        public void Send(NetworkMessage message)
        {
            _clients.ForEach(x => x.SendAsync(message));
        }

        public List<GameRolePlayCharacterInformations> GetActorInformations()
        {
            return _clients.Select(actor => actor.Character.GetGameRolePlayCharacterInformations()).ToList();
        }

        public List<GameRolePlayActorInformations> GetGameRolePlayActorInformationses()
        {
            var toRet = new List<GameRolePlayActorInformations>();
            foreach (var client in _clients)
            {
                toRet.Add(client.Character.GetGameRolePlayCharacterInformations());
            }
            return toRet;
        }

        public void RefreshActor() => _clients.ForEach(
            client => client.SendAsync(
                new GameRolePlayShowActorMessage(client.Character.GetGameRolePlayCharacterInformations())));

        private void SendGameRolePlayShowActorMessage(Client client)
        {
            foreach(var c in _clients)
                client.SendAsync(new GameRolePlayShowActorMessage(c.Character.GetGameRolePlayCharacterInformations()));
        }

    }
}
