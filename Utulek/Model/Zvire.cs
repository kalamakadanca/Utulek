using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek.Model
{
    internal class Zvire
    {
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

        public void OznacitAdopci()
        {
            Adopce = true;
        }

        public int GetID()
        {
            return ID;
        }
        public string GetJmeno()
        {
            return Jmeno;
        }
        public string GetDruh()
        {
            return Druh;
        }
        public int GetVek()
        {
            return Vek;
        }
        public string GetPohlavi()
        {
            return Pohlavi;
        }
        public string GetDatumPrijmu()
        {
            return DatumPrijmu;
        }
        public string GetZdravotniStav()
        {
            return ZdravotniStav;
        }
        public string GetPoznamka()
        {
            return Poznamka;
        }
        public bool GetAdopce()
        {
            return Adopce;
        }
        public string GetDatumAdopce()
        {
            return DatumAdopce;
        }

    }
}
