﻿namespace CookieEmu.API.Protocol.Network.Types.Common.Basic
{
    using CookieEmu.API.IO;

    public class StatisticData : NetworkType
    {
        public const ushort ProtocolId = 484;
        public override ushort TypeID => ProtocolId;

        public StatisticData() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
