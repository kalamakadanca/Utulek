using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utulek.Model;

namespace Utulek.Services
{
    public class EvidenceUtulku
    {

        public static void ZapisZvireDoSouboru(string Soubor, Zvire Zvire)
        {
            string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string FullPath = Path.Combine(ProjectPath, Soubor);
        string ZvireTemp = $"{Zvire.ID}@{Zvire.Jmeno}@{Zvire.Druh}@{Zvire.Vek}@{Zvire.Pohlavi}@{Zvire.DatumPrijmu}@{Zvire.ZdravotniStav}@{Zvire.Poznamka}@{Zvire.Adoptovano}@{Zvire.DatumAdopce}";  
            using (StreamWriter sw = new StreamWriter(FullPath, true))
            {
                sw.WriteLine(ZvireTemp);
            }
        }

        public static List<Zvire> VypisZvireZeSouboru(string Soubor)
        {
            string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string FullPath = Path.Combine(ProjectPath, Soubor);
            List<Zvire> Zvirata = new List<Zvire>();
            using (StreamReader sr = new StreamReader(FullPath))
            {
                string Line;
                while ((Line = sr.ReadLine()) != null)
                {
                    List<string> Parts = Line.Split('@').ToList();
                    Zvire zvire = new Zvire(int.Parse(Parts[0]), Parts[1], Parts[2], int.Parse(Parts[3]), Parts[4], Parts[5], Parts[6], Parts[7], Parts[8], Parts[9]);
                    Zvirata.Add(zvire);
                }
            }
            return Zvirata;
        }

        public static void ZapisZvireAutoID(string Soubor, Zvire Zvire)
        {
            List<Zvire> Zvirata = VypisZvireZeSouboru(Soubor);
            int MaxID = 0;
            foreach (var zvire in Zvirata)
            {
                if (zvire.ID > MaxID)
                {
                    MaxID = zvire.ID;
                }
            }
            Zvire.ID = MaxID + 1;
            ZapisZvireDoSouboru(Soubor, Zvire);
        }
    }
}

