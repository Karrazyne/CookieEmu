using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CookieEmu.API.Protocol.Network.Messages.Handshake;

namespace CookieEmu.API.Protocol
{
    public static class MessageIdentifier
    {
        private static readonly Dictionary<uint, string> Packets = new Dictionary<uint, string>();

        public static void Initialize()
        {
            var asm = Assembly.GetAssembly(typeof(ProtocolRequired));
            foreach (var type in asm.GetTypes().Where(x => x.IsSubclassOf(typeof(NetworkMessage))))
            {
                var property = type.GetProperty("MessageID");
                if (property == null) continue;
                var id = Convert.ToUInt32(property.GetValue(Activator.CreateInstance(type), null));
                if (Packets.ContainsKey(id)) continue;
                Packets.Add(id, type.Name);
            }
            Console.WriteLine($"Loading {Packets.Count} Messages...");
        }

        public static string GetMessageName(uint id) => Packets[id];
    }
}
