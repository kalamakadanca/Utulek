using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek.Model
{
    internal class Zvire
    {
        public int ID;
        public string Jmeno;
        public string Druh;
        public int Vek;
        public string Pohlavi;
        public string DatumPrijmu; // dd/mm/yyyy př.10/9/2025
        public string ZdravotniStav;
        public string Poznamka;

        public Zvire(string jmeno, string druh, int vek, string pohlavi, string datumprijmu, string zdravotnistav, string poznamka)
        {
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Pohlavi = pohlavi;
            DatumPrijmu = datumprijmu;
            ZdravotniStav = zdravotnistav;
            Poznamka = poznamka;
        }

    }
}
