using System;
using System.Reflection;

namespace CookieEmu.Auth.Engine.Types
{
    public class InstanceInfo
    {
        #region Properties
        public uint ProtocolId { get; set; }

        public Type MessageType { get; set; }

        public MethodInfo Method { get; set; }
        #endregion

        #region Constructeurs
        public InstanceInfo(uint protocolId, Type messageType, MethodInfo method)
        {
            ProtocolId = protocolId;
            MessageType = messageType;
            Method = method;
        }
        #endregion
    }
}
