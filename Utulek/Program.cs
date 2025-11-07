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

        public Zvire(int id, string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka)
        {
            ID = id;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumPrijmu;
            ZdravotniStav = zdravotniStav;
            Poznamka = poznamka;
        }
    }
    
    internal class Program
    {
        static void ZapisZvireDoSouboru(string Soubor, Zvire Zvire)
        {
        string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        string FullPath = Path.Combine(ProjectPath, Soubor);
            string ZvireTemp = $"{Zvire.ID}@{Zvire.Jmeno}@{Zvire.Druh}@{Zvire.Vek}@{Zvire.Pohlavi}@{Zvire.DatumPrijmu}@{Zvire.ZdravotniStav}@{Zvire.Poznamka}";
            // 1@Benny@pes@3@muz@2022-05-10@zdravy@pritelny a hravy - forma zapisu
        using (StreamWriter sw = new StreamWriter(FullPath, true))
        {
            sw.WriteLine(ZvireTemp);
        }
    }
        static void Main(string[] args)
        {
            Zvire zvire1 = new Zvire(1, "Benny", "pes", 3, "muz","2022/5/10", "zdravy", "pritelny a hravy");
            Zvire zvire2 = new Zvire(2, "Micka", "kocka", 2, "zena", "2023/1/15", "zdrava", "klidna a mazliva");

            ZapisZvireDoSouboru("zvirata.txt", zvire1);
            ZapisZvireDoSouboru("zvirata.txt", zvire2);
        }
    }
}
