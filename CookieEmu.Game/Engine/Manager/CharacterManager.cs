using System.Collections.Generic;
using System.Linq;
using CookieEmu.Game.SQL.Character;

namespace CookieEmu.Game.Engine.Manager
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

        public static bool NameExist(string name)
        {
            using (var context = new CharacterModel())
            {
                var characters = (from c in context.characters
                    where c.Name == name
                    select c).ToList();
                return characters.Count > 0;
            }
        }

        public static void CreateCharacter(Character character)
        {
            using (var context = new CharacterModel())
            {
                context.Database.ExecuteSqlCommand(
                    $"INSERT INTO characters SET OwnerId = '{character.OwnerId}', Name = '{character.Name}', Level = '{character.Level}', Experience = '{character.Experience}'," +
                    $"Breed = '{character.Breed}', EntityLookString = '{character.EntityLookString}', Sex = '{character.Sex}', MapId = '{character.MapId}', CellId = '{character.CellId}', " +
                    $"Direction = '{character.Direction}'");
                context.SaveChanges();
            }
        }
    }
}
