using System;
using System.Collections.Generic;
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
            DatabaseManager.Connect("127.0.0.1", "root", "", "cookieemu");
            //GenerateTitle();
            //GenerateBreed();
            GenerateHead();
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
    }
    }
