namespace CookieEmu.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Enums;
    using System.Collections.Generic;
    using CookieEmu.API.IO;

    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 160;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }
        public List<int> Colors { get; set; }

        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, ushort cosmeticId, List<int> colors)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public CharacterCreationRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            for (var i = 0; i < 5; i++)
            {
                writer.WriteInt(Colors[i]);
            }
            writer.WriteVarUhShort(CosmeticId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Colors = new List<int>(5);
            for (var i = 0; i < 5; i++)
            {
                Colors.Add(reader.ReadInt());
            }
            CosmeticId = reader.ReadVarUhShort();
        }

    }
}
