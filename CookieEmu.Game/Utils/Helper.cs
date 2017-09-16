using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.API.Protocol.Enums;
using CookieEmu.API.Protocol.Network.Types.Game.Look;
using CookieEmu.Game.SQL.Breeds;
using CookieEmu.Game.SQL.Character;

namespace CookieEmu.Game.Utils
{
    public class Helper
    {
        public static EntityLook EntityLookBuilder(Character character)
        {
            try
            {
                var tempString = character.EntityLookString;
                var look = tempString.Split(',');
                var lookString = look[0].Replace("{", "").Replace("}", "").Split('|');
                var bonesId = uint.Parse(lookString[0]);
                var breadHead = int.Parse(look[6]);
                var skin = new[] {ushort.Parse(lookString[1]), (ushort)Head.GetHeadSkin(breadHead)};
                var colorsString = (look[1] + "," + look[2] + "," + look[3] + "," + look[4] + "," + look[5]).Split(',');
                var colors = new List<int>(colorsString.Length);
                for (var i = 0; i < colorsString.Length; i++)
                {
                    var color = int.Parse(colorsString[i]);
                    if (color != -1)
                        colors.Add((i + 1 & 255) << 24 | color & 16777215);
                }
                var scales = new List<short> {short.Parse(lookString[3])};
                return new EntityLook((ushort) bonesId, skin.ToList(), colors, scales, GetSubEntities(character));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<SubEntity> GetSubEntities(Character character)
        {
            var returnSubEntities = new List<SubEntity>();

            if (character.Direction == (byte) DirectionsEnum.DIRECTION_SOUTH && character.Level >= 100 &&
                character.Level != 200)
            {
                returnSubEntities.Add(new SubEntity
                {
                    BindingPointCategory = 6,
                    BindingPointIndex = 0,
                    SubEntityLook = new EntityLook(169, new List<ushort>(), new List<int>(),new List<short>(), new List<SubEntity>())
                });
            }
            else if (character.Direction == (byte) DirectionsEnum.DIRECTION_SOUTH && character.Level == 200)
            {
                returnSubEntities.Add(new SubEntity
                {
                    BindingPointCategory = 6,
                    BindingPointIndex = 0,
                    SubEntityLook = new EntityLook(170, new List<ushort>(), new List<int>(), new List<short>(), new List<SubEntity>())
                });
            }
            return returnSubEntities;
        }
    }
}
