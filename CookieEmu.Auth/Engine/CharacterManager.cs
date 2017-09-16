using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieEmu.Auth.SQL;

namespace CookieEmu.Auth.Engine
{
    public class CharacterManager
    {
        public static List<Character> ReturnCharacters(int accountId)
        {
            using (var context = new CharacterModel())
            {
                var characters = (from c in context.characters
                    where c.OwnerId == accountId
                    select c).ToList();

                return characters;
            }
        }
    }
}
