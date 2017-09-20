using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using D2OSync.D2i;
using D2OSync.D2o;
using D2OSync.Database;
using D2OSync.Datacenter;
using D2OSync.Models;

namespace D2OSync
{
    static class Program
    {
        static void Main(string[] args)
        {
            FastD2IReader.Instance.Init(@"D:\Dofus 2.43\app\data\i18n\i18n_fr.d2i");
            DatabaseManager.Connect("127.0.0.1", "root", "", "test");
            //GenerateTitle();
            //GenerateBreed();
            //GenerateHead();
            //GenerateInteractive();
            //GenerateJob();
            GenerateSkills();
            //GenerateSkillName();

            Console.WriteLine("done");
            Console.Read();
        }

        private static void GenerateTitle()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Titles.d2o");
            var titles = data.ReadObjects<Title>();
            var tempTitles = titles.Values.Select(title => new TitleModel(title)).ToList();
            Console.WriteLine(@"Title Done");

            data = null;
            titles = null;
            tempTitles = null;
        }

        private static void GenerateBreed()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Breeds.d2o");
            var breeds = data.ReadObjects<Breed>();
            var tempBreeds = breeds.Values.Select(x => new BreedModel(x)).ToList();

            data = null;
            breeds = null;
            tempBreeds = null;
        }

        private static void GenerateHead()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Heads.d2o");
            var heads = data.ReadObjects<Head>();
            var tempHead = heads.Values.Select(x => new HeadModel(x)).ToList();

            data = null;
            heads = null;
            tempHead = null;
        }

        private static void GenerateInteractive()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Interactives.d2o");
            var interactive = data.ReadObjects<Interactive>();

            using (var writer = new StreamWriter("./interactive.txt"))
            {
                foreach (var value in interactive.Values)
                {
                    writer.WriteLine($"Id: {value.Id} ActionId: {value.ActionId} Tooltip: {value.DisplayTooltip} Name: {FastD2IReader.Instance.GetText(value.NameId)}");
                    DatabaseManager.ExecuteNonQuery(
                        $"INSERT INTO interactives SET Id = '{value.Id}', ActionId = '{value.ActionId}', Name = '{FastD2IReader.Instance.GetText(value.NameId).Replace("'", "")}'");
                }
            }
            Console.WriteLine("done");
            
        }

        private static void GenerateJob()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Jobs.d2o");
            var jobs = data.ReadObjects<Job>();

            foreach (var job in jobs.Values)
            {
                Console.WriteLine($"Id: {job.Id} Name: {FastD2IReader.Instance.GetText(job.NameId)}");
            }
        }

        private static void GenerateSkills()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\Skills.d2o");
            var skills = data.ReadObjects<Skill>();
            using (var writer = new StreamWriter("./Skills.txt"))
            {
                foreach (var skill in skills.Values)
                {
                    DatabaseManager.ExecuteNonQuery(
                        $"INSERT INTO skills SET Id = '{skill.Id}', ElementActionId = '{skill.ElementActionId}', InteractiveId = '{skill.InteractiveId}', Name = '{FastD2IReader.Instance.GetText(skill.NameId).Replace("'","")}'");
                    //writer.WriteLine($"Id: {skill.Id} InteractiveId: {skill.InteractiveId} Name: {FastD2IReader.Instance.GetText(skill.NameId)} ElementActionId: {skill.ElementActionId}");
                }
            }
        }

        private static void GenerateSkillName()
        {
            var data = new D2oReader(@"D:\Dofus 2.43\app\data\common\SkillNames.d2o");
            var names = data.ReadObjects<SkillName>();
            foreach (var name in names.Values)
            {
                Console.WriteLine(FastD2IReader.Instance.GetText(name.NameId));
            }
        }
    }
 }
