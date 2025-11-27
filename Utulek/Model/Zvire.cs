using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek.Model
{
    public class Zvire
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public string Pohlavi { get; set; }
        public string DatumPrijmu { get; set; } // dd/mm/yyyy př.10/09/2025
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public bool Adopce { get; set; }
        public string DatumAdopce { get; set; } // dd/mm/yyyy př.10/09/2025

        public Zvire(int id, string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, bool adopce, string datumAdopce)
        {
            ID = id;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumPrijmu;
            ZdravotniStav = zdravotniStav;
            Poznamka = poznamka;
            Adopce = adopce;
            DatumAdopce = datumAdopce;

        }


        public Zvire(string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, bool adopce, string datumAdopce)
        {
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumPrijmu;
            ZdravotniStav = zdravotniStav;
            Poznamka = poznamka;
            Adopce = adopce;
            DatumAdopce = datumAdopce;
        }


        public void OznacitAdopci()
        {
            Adopce = true;
            DatumAdopce = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
