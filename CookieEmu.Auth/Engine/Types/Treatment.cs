using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CookieEmu.API.IO;
using CookieEmu.API.Protocol;
using CookieEmu.Auth.Engine.Handler;
using CookieEmu.Auth.Network;

namespace CookieEmu.Auth.Engine.Types
{
    public class Treatment
    {
        #region Fields
        private readonly List<InstanceInfo> _mInstances = new List<InstanceInfo>();
        #endregion

        #region Constructeurs
        public Treatment()
        {
            GetTypes(Assembly.GetExecutingAssembly().ToString());
        }
        #endregion

        #region Public methods

        public void Treat(int packetId, byte[] packetDatas, Client client)
        {
            var enqueue = _mInstances.Where(instance => instance.ProtocolId == packetId).ToList();

            client.Log(enqueue.Count(x => x.ProtocolId == packetId) > 0
                ? $"[RCV] ({packetId}) {MessageIdentifier.GetMessageName((uint) packetId)}"
                : $"[RCV] ({packetId}) {MessageIdentifier.GetMessageName((uint) packetId)} not handled");

            foreach (var instance in enqueue)
            {
                var message = (NetworkMessage) Activator.CreateInstance(instance.MessageType);
                var method = instance.Method;

                using (var reader = new BigEndianReader(packetDatas))
                    message.Deserialize(reader);

                object[] parameters = {message, client };

                method.Invoke(null, parameters);
            }
        }

        #endregion

        #region Private methods
        private void GetTypes(string assemblyName)
        {
            var assembly = Assembly.Load(assemblyName);

            foreach (
                var instance in
                    from method in assembly.GetTypes().Select(type => type.GetMethods()).SelectMany(methods => methods)
                    let messageHandler =
                        (MessageHandler) Attribute.GetCustomAttribute(method, typeof (MessageHandler), false)
                    where messageHandler != null
                    let message = (NetworkMessage) (Activator.CreateInstance(messageHandler.MessageType))
                    select new InstanceInfo((uint) message.MessageID, messageHandler.MessageType, method))
                _mInstances.Add(instance);
        }

        #endregion
    }
}
