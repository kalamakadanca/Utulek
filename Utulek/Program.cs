using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // pro operace se soubory
using System.Threading.Tasks;
using Utulek.Model;

namespace Utulek
{
    internal class Zvire
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public string Pohlavi { get; set; }
        public string DatumPrijmu { get; set; }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public string Adoptovano { get; set; }
        public string DatumAdopce { get; set; }

        public Zvire(int id, string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, string adoptovano,  string datumAdopce)
        {
            ID = id;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumPrijmu;
            ZdravotniStav = zdravotniStav;
            Poznamka = poznamka;
            Adoptovano = adoptovano;
            DatumAdopce = datumAdopce;
            
        }
    }
    
    internal class Program
    {
        static void ZapisZvireDoSouboru(string Soubor, Zvire Zvire)
        {
            //TODO- I need to create an automatic generation of id based on the last id
            // TODO- I do not know if I should create a filter based on this thing
            //TODO- I need to create a delete function based on id
            //TODO- I need to create a filtered output reading based on species, age and name
            string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string FullPath = Path.Combine(ProjectPath, Soubor);
            string ZvireTemp = $"{Zvire.ID}@{Zvire.Jmeno}@{Zvire.Druh}@{Zvire.Vek}@{Zvire.Pohlavi}@{Zvire.DatumPrijmu}@{Zvire.ZdravotniStav}@{Zvire.Poznamka}@ne@neadoptovano";
            // 1@Benny@pes@3@muz@2022-05-10@zdravy@pritelny a hravy@ano/ne@2024-07-12 - forma zapisu
            using (StreamWriter sw = new StreamWriter(FullPath, true))
            {
                sw.WriteLine(ZvireTemp);
            }
        }

        static List<Zvire> VypisZvireZeSouboru(string Soubor)
        {
            string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string FullPath = Path.Combine(ProjectPath, Soubor);
            List<Zvire> Zvirata = new List<Zvire>();
            using (StreamReader sr = new StreamReader(FullPath))
            {
                string Line;
                while ((Line = sr.ReadLine()) != null)
                {
                    List<string> Parts = Line.Split('@').ToList();
                    Zvire zvire = new Zvire(int.Parse(Parts[0]), Parts[1], Parts[2], int.Parse(Parts[3]), Parts[4], Parts[5], Parts[6], Parts[7], Parts[8], Parts[9]);
                    Zvirata.Add(zvire);
                }
            }
            return Zvirata;
        }
            
        static void Main(string[] args)
        {
            Zvire zvire1 = new Zvire(1, "Benny", "pes", 3, "male","2022/5/10", "zdravy", "pritelny a hravy", "ne", "neadoptovano");
            Zvire zvire2 = new Zvire(2, "Micka", "kocka", 2, "female", "2023/1/15", "zdrava", "klidna a mazliva", "Adoptovano", "2024/6/1");

            ZapisZvireDoSouboru("zvirata.txt", zvire1);
            ZapisZvireDoSouboru("zvirata.txt", zvire2);

            List<Zvire> Zverina = VypisZvireZeSouboru("zvirata.txt");
            foreach (var zvire in Zverina)
            {
                Console.WriteLine(zvire.Jmeno + zvire.ID + zvire.Vek);
            }
        }
    }
}
