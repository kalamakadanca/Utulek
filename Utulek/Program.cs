using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // pro operace se soubory
using System.Threading.Tasks;
using Utulek.Model;

namespace Utulek
{
    
    internal class Program
    {
        static void ZapisZvireDoSouboru(string Soubor, Zvire Zvire)
    {
            string zvireparse = $"{Zvire.ID}@{Zvire.Jmeno}@{Zvire.Druh}@{Zvire.Vek}@{Zvire.Pohlavi}@{Zvire.DatumPrijmu}@{Zvire.ZdravotniStav}@{Zvire.Poznamka}";
            // 1@Benny@pes@3@muz@2022-05-10@zdravy@pritelny a hravy - forma zapisu
        using (StreamWriter sw = new StreamWriter(Soubor, true))
        {
            sw.WriteLine(zvireparse);
        }
    }
        static void Main(string[] args)
        {
        }
    }
}
