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
        public string DatumPrijmu { get; set; }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public string Adoptovano { get; set; }
        public string DatumAdopce { get; set; }

        public Zvire(int id, string jmeno, string druh, int vek, string pohlavi, string datumPrijmu, string zdravotniStav, string poznamka, string adoptovano, string datumAdopce)
        {
            ID = id;
            private int ID;
            private string Jmeno;
            private string Druh;
            private int Vek;
            private string Pohlavi;
            private string DatumPrijmu; // dd/mm/yyyy př.10/9/2025
            private string ZdravotniStav;
            private string Poznamka;
            private bool Adopce = false;
            private string DatumAdopce; // dd/mm/yyyy př.10/9/2025
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

        public void OznacitAdopci()
        {
            Adopce = true;
        }

    }
}
