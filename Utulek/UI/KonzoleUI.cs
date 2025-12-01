using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utulek.Model;
using Utulek.Services;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Utulek.UI
{
    internal class KonzoleUI
    {
        public static void ValidaceVstupu(string[] args)
        {
            bool end = true;
            int volba;
            string pattern_words = "^.+$";
            Regex regex_words = new Regex(pattern_words);
            List<Zvire> zverina;

            while (end)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==== ÚTULEK PRO ZVÍŘATA ====");
                Console.ResetColor();
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat/filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("0) Konec");
                volba = -1;
                while (volba < 0)
                {
                    Console.Write("Zadejte číslo volby: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out volba))
                    {
                        Console.WriteLine("Neplatný vstup, zadejte číslo.");
                        volba = -1;
                    }
                    if (volba < 0)
                    {
                        Console.WriteLine("Neplatný vstup, zadejte nezáporné číslo.");
                        volba = -1;
                    }
                }

                switch (volba)
                {
                    case 1:
                        string jmeno = "";
                        while (!regex_words.IsMatch(jmeno))
                        {
                            Console.WriteLine("Jméno zvířete:");
                            jmeno = Console.ReadLine();
                        }
                        string druh = "";
                        while (!regex_words.IsMatch(druh))
                        {
                            Console.WriteLine("Druh zvířete:");
                            druh = Console.ReadLine();
                        }
                        int vek = -1;
                        while (vek < 0) {
                            Console.WriteLine("Věk zvířete:");
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out vek))
                            {
                                Console.WriteLine("Neplatný vstup, zadejte číslo.");
                                vek = -1;
                            }
                        }
                        string pohlavi = "";
                        while (!regex_words.IsMatch(pohlavi))
                        {
                            Console.WriteLine("Pohlaví zvířete:");
                            pohlavi = Console.ReadLine();
                        }
                        Console.WriteLine("Datum přijetí (dd/mm/yyyy):");
                        string datumPrijmu = Console.ReadLine();
                        string zdravotniStav = "";
                        while (!regex_words.IsMatch(zdravotniStav))
                        {
                            Console.WriteLine("Zdravotní stav zvířete:");
                            zdravotniStav = Console.ReadLine();
                        }
                        string poznamka = "";
                        while (!regex_words.IsMatch(poznamka))
                        {
                            Console.WriteLine("Poznámka:");
                            poznamka = Console.ReadLine();
                        }
                        Console.WriteLine("Bylo zvíře adoptováno? (ano/ne):");
                        string adopceInput = Console.ReadLine();
                        bool adopce = adopceInput.ToLower() == "ano";
                        string datumAdopce = adopce ? DateTime.Now.ToString("dd/MM/yyyy") : "neadoptovano";
                        Utulek.Model.Zvire noveZvire = new Utulek.Model.Zvire(jmeno, druh, vek, pohlavi, datumPrijmu, zdravotniStav, poznamka, adopce, datumAdopce);
                        EvidenceUtulku.ZapisZvireDoSouboru("zvirata.txt", noveZvire);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Stiskni libovolnou klávesu pro pokračování");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Seznam všech zvířat v útulku:");
                        zverina = EvidenceUtulku.VypisZvireZeSouboru("zvirata.txt");
                        foreach (var zvire in zverina)
                        {
                            Console.WriteLine($"jméno: {zvire.Jmeno}, id: {zvire.ID}, věk: {zvire.Vek}");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Stiskni libovolnou klávesu pro pokračování");
                        Console.ResetColor();
                        Console.ReadKey();
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
                            List<Zvire> Zverina = EvidenceUtulku.FiltrZviratVek("zvirata.txt", vekFilter, operat);
                            foreach (var zvire in Zverina)
                            {
                                Console.WriteLine($"jméno: {zvire.Jmeno}, id: {zvire.ID}, věk: {zvire.Vek}");
                            }
                        }
                        else if (filterVolba == 2)
                        {
                            Console.WriteLine("napiš druh zvířete");
                            string druhFilter = Console.ReadLine();
                            List<Zvire> Zverina = EvidenceUtulku.FiltrZviratDruh("zvirata.txt", druhFilter);
                            foreach (var zvire in Zverina)
                            {
                                Console.WriteLine($"jméno: {zvire.Jmeno}, id: {zvire.ID}, věk: {zvire.Vek}");
                            }
                        }
                        else if (filterVolba == 1)
                        {
                            Console.WriteLine("napiš jméno zvířete");
                            string jmenoFilter = Console.ReadLine();
                            List<Zvire> Zverina = EvidenceUtulku.FiltrZviratJmeno("zvirata.txt", jmenoFilter);
                            foreach (var zvire in Zverina)
                            {
                                Console.WriteLine($"jméno: {zvire.Jmeno}, id: {zvire.ID}, věk: {zvire.Vek}");
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Stiskni libovolnou klávesu pro pokračování");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Zadejte ID zvířete k označení adopce:");
                        int id = -1;
                        while (id < 0)
                        {
                            Console.WriteLine("Zadejte ID zvířete k označení adopce:");
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out id))
                            {
                                Console.WriteLine("Neplatný vstup, zadejte číslo.");
                                id = -1;
                            }
                        }
                        List<Zvire> zver = EvidenceUtulku.VypisZvireZeSouboru("zvirata.txt");
                        zver.Find(z => z.ID == id).OznacitAdopci();
                        EvidenceUtulku.UpdateZvireVSouboru("zvirata.txt", zver.Find(z => z.ID == id));
                        // TODO - volani funkce pro oznaceni adopce
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Stiskni libovolnou klávesu pro pokračování");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    case 0:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Stiskni libovolnou klávesu pro pokračování");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
