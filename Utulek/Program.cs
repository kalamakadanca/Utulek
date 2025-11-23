using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // pro operace se soubory
using System.Threading.Tasks;
using Utulek.Model;
using Utulek.Services;

namespace Utulek
{
    class Program
    {
        static void Main(string[] args)
        {
            Zvire zvire1 = new Zvire(1, "Benny", "pes", 3, "male", "2022/5/10", "zdravy", "pritelny a hravy", "ne", "neadoptovano");
            Zvire zvire2 = new Zvire(2, "Micka", "kocka", 2, "female", "2023/1/15", "zdrava", "klidna a mazliva", "ano", "2024/6/1");

            EvidenceUtulku.ZapisZvireDoSouboru("zvirata.txt", zvire1);
            EvidenceUtulku.ZapisZvireDoSouboru("zvirata.txt", zvire2);
            
            Zvire zvire3 = new Zvire("Rex", "pes", 4, "male", "2021/11/20", "zdravy", "ochranny a energicky", "ne", "neadoptovano");
            EvidenceUtulku.ZapisZvireAutoID("zvirata.txt", zvire3);
            EvidenceUtulku.SmazatZvireZeSouboru("zvirata.txt",3);

            List <Zvire> Zverina = EvidenceUtulku.VypisZvireZeSouboru("zvirata.txt");
            foreach (var zvire in Zverina)
            {
                Console.WriteLine(zvire.Jmeno + zvire.ID + zvire.Vek);
            }
        }
    }
}