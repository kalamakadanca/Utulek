using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // pro operace se soubory
using System.Threading.Tasks;
using Utulek.Model;
using System.Security.Policy;

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

        public Zvire(int id, string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, string adoptovano, string datumAdopce)
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
        public Zvire(string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, string adoptovano, string datumAdopce)
        {
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
        static void Main(string[] args)
        {
            Zvire zvire1 = new Zvire(1, "Benny", "pes", 3, "male", "2022/5/10", "zdravy", "pritelny a hravy", "ne", "neadoptovano");
            Zvire zvire2 = new Zvire(2, "Micka", "kocka", 2, "female", "2023/1/15", "zdrava", "klidna a mazliva", "Adoptovano", "2024/6/1");

            Evidence.ZapisZvireDoSouboru("zvirata.txt", zvire1);
            Evidence.ZapisZvireDoSouboru("zvirata.txt", zvire2);

            List<Zvire> Zverina = Evidence.VypisZvireZeSouboru("zvirata.txt");
            foreach (var zvire in Zverina)
            {
                Console.WriteLine(zvire.Jmeno + zvire.ID + zvire.Vek);
            }
        }
    }
}
