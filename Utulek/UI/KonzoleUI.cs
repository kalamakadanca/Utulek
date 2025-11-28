using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utulek.Model;
using Utulek.Services;

namespace Utulek.UI
{
    internal class KonzoleUI
    {
        public static void ValidaceVstupu(string[] args)
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
                switch (volba)
                {
                    case 1:
                        Console.WriteLine("Jméno zvířete:");
                        string jmeno = Console.ReadLine();
                        Console.WriteLine("Druh zvířete:");
                        string druh = Console.ReadLine();
                        Console.WriteLine("Věk zvířete:");
                        int vek = int.Parse(Console.ReadLine());
                        Console.WriteLine("Pohlaví zvířete:");
                        string pohlavi = Console.ReadLine();
                        Console.WriteLine("Datum přijetí (dd/mm/yyyy):");
                        string datumPrijmu = Console.ReadLine();
                        Console.WriteLine("Zdravotní stav zvířete:");
                        string zdravotniStav = Console.ReadLine();
                        Console.WriteLine("Poznámka:");
                        string poznamka = Console.ReadLine();
                        Console.WriteLine("Bylo zvíře adoptováno? (ano/ne):");
                        string adopceInput = Console.ReadLine();
                        bool adopce = adopceInput.ToLower() == "ano";
                        string datumAdopce = adopce ? DateTime.Now.ToString("dd/MM/yyyy") : "neadoptovano";
                        Utulek.Model.Zvire noveZvire = new Utulek.Model.Zvire(jmeno, druh, vek, pohlavi, datumPrijmu, zdravotniStav, poznamka, adopce, datumAdopce);
                        EvidenceUtulku.ZapisZvireDoSouboru("zvirata.txt", noveZvire);
                        break;
                    case 2:
                        Console.WriteLine("Seznam všech zvířat v útulku:");
                        Console.WriteLine(EvidenceUtulku.VypisZvireZeSouboru("zvirata.txt"));
                        break;
                    case 3:
                        Console.WriteLine("Zadejte, podle čeho chcete filtrovat: ");
                        Console.WriteLine("1) Jméno");
                        Console.WriteLine("2) Druh");
                        Console.WriteLine("3) Věk");
                        int filterVolba = int.Parse(Console.ReadLine());
                        if (filterVolba == 3)
                        {

                            Console.WriteLine("napiš věk zvířete");
                            int vekFilter = int.Parse(Console.ReadLine());
                            Console.WriteLine("Zadejte operátor filtru (>, <, =):");
                            string operat = Console.ReadLine();
                            Console.WriteLine(EvidenceUtulku.FiltrZviratVek("zvirata.txt", vekFilter, operat));
                        }
                        else if (filterVolba == 2)
                        {
                            Console.WriteLine("napiš druh zvířete");
                            string druhFilter = Console.ReadLine();
                            Console.WriteLine(EvidenceUtulku.FiltrZviratDruh("zvirata.txt", druhFilter));
                        }
                        else if (filterVolba == 1)
                        {
                            Console.WriteLine("napiš jméno zvířete");
                            string jmenoFilter = Console.ReadLine();
                            Console.WriteLine(EvidenceUtulku.FiltrZviratJmeno("zvirata.txt", jmenoFilter));
                        }
                        break;
                    case 4:
                        Console.WriteLine("Zadejte ID zvířete k označení adopce:");
                        int id = int.Parse(Console.ReadLine());

                        break;
                    case 0:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        break;
                }
            }
        }
    }
}
