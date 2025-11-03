using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utulek.UI
{
    internal class KonzoleUI
    {
        static void ValidaceVstupu(string[] args)
        {
            bool end = true;
            int volba;
            while (end)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==== ÚTULEK PRO ZVÍŘATA ====");
                Console.ResetColor();
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat/filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("0) Konec");
                Console.Write("Zadejte číslo volby: ");
                volba = int.Parse(Console.ReadLine());
            }
        }
    }
}
