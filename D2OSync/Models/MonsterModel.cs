using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2OSync.D2i;
using D2OSync.Database;
using D2OSync.Datacenter;

namespace D2OSync.Models
{
    public class MonsterModel
    {
        public int Id { get; set; }
        public string AllIdolsDisabled { get; set; }
        public string CanBePushed { get; set; }
        public string CanPlay { get; set; }
        public string CanSwitchPos { get; set; }
        public string CanTackle { get; set; }
        public int CorrespondingMiniBossId { get; set; }
        public int CreatureBoneId { get; set; }
        public string DareAvailable { get; set; }
        public int FavoriteSubAreaId { get; set; }
        public int GfxId { get; set; }
        public string IncompatibleChallenges { get; set; }
        public string IncompatibleIdols { get; set; }
        public string IsBoss { get; set; }
        public string IsMiniBoss { get; set; }
        public string IsQuestMonsterId { get; set; }
        public string Look { get; set; }
        public int NameId { get; set; }
        public string Name { get; set; }
        public int Race { get; set; }
        public string Spells { get; set; }
        public string SubAreas { get; set; }

        public string Query { get; set; }

        private Monster Monster { get; }

        public MonsterModel(Monster monster)
        {
            Monster = monster;
            SetMonster();
        }

        private void SetMonster()
        {
            Id = Monster.Id;
            AllIdolsDisabled = GetBool(Monster.AllIdolsDisabled);
            CanBePushed = GetBool(Monster.CanBePushed);
            CanPlay = GetBool(Monster.CanPlay);
            CanSwitchPos = GetBool(Monster.CanSwitchPos);
            CanTackle = GetBool(Monster.CanTackle);
            CorrespondingMiniBossId = (int) Monster.CorrespondingMiniBossId;
            CreatureBoneId = Monster.CreatureBoneId;
            DareAvailable = GetBool(Monster.DareAvailable);
            FavoriteSubAreaId = Monster.FavoriteSubareaId;
            GfxId = (int)Monster.GfxId;
            IncompatibleChallenges = string.Join(",", Monster.IncompatibleChallenges);
            IncompatibleIdols = string.Join(",", Monster.IncompatibleIdols);
            IsBoss = GetBool(Monster.IsBoss);
            IsMiniBoss = GetBool(Monster.IsMiniBoss);
            IsQuestMonsterId = GetBool(Monster.IsQuestMonster);
            Look = Monster.Look;
            NameId = (int) Monster.NameId;
            Name = FastD2IReader.Instance.GetText(NameId).Replace("'", "");
            Race = Monster.Race;
            Spells = string.Join(",", Monster.Spells);
            SubAreas = string.Join(",", Monster.Subareas);
            GenerateQuery();
        }

        private void GenerateQuery()
        {
            Query =
                $"INSERT INTO monsters SET Id = '{Id}', AllIdolsDisabled = '{AllIdolsDisabled}', CanBePushed = '{CanBePushed}', CanPlay = '{CanPlay}', CanSwitchPos = '{CanSwitchPos}', CanTackle = '{CanTackle}', CorrespondingMiniBossId = '{CorrespondingMiniBossId}', CreatureBoneId = '{CreatureBoneId}', DareAvailable = '{DareAvailable}', FavoriteSubareaId = '{FavoriteSubAreaId}', GfxId = '{GfxId}', IncompatibleChallenges = '{IncompatibleChallenges}', IncompatibleIdols = '{IncompatibleIdols}', IsBoss = '{IsBoss}', IsMiniBoss = '{IsMiniBoss}', IsQuestMonster = '{IsQuestMonsterId}', Look = '{Look}', NameId = '{NameId}', Name = '{Name}', Race = '{Race}', Spells = '{Spells}', Subareas = '{SubAreas}'";
            DatabaseManager.ExecuteNonQuery(Query);
            Console.WriteLine(@"Added to sql");
        }

        private static string GetBool(bool value)
        {
            return value ? "true" : "false";
        }
    }
}
