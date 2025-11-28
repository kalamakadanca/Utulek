using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utulek.Model;
using System.Diagnostics;
using System.Runtime.InteropServices;

//TODO- I need to create an automatic generation of id based on the last id -- done
//TODO- I need to create a delete function based on id -- done
//TODO- I need to create a filtered output reading based on species, age and name - done

namespace Utulek.Services
{
    public class EvidenceUtulku
    {

        
        public static string ConvertBoolToString(bool value)
        {
            return value ? "ano" : "ne";
        }

        public static bool ConvertStringToBool(string value)
        {
            if (value.ToLower() == "ano")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ZapisZvireDoSouboru(string Soubor, Zvire Zvire)
        {
            string ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string FullPath = Path.Combine(ProjectPath, Soubor);
        string ZvireTemp = $"{Zvire.ID}@{Zvire.Jmeno}@{Zvire.Druh}@{Zvire.Vek}@{Zvire.Pohlavi}@{Zvire.DatumPrijmu}@{Zvire.ZdravotniStav}@{Zvire.Poznamka}@{ConvertBoolToString(Zvire.Adopce)}@{Zvire.DatumAdopce}";  
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
                    Zvire zvire = new Zvire(int.Parse(Parts[0]), Parts[1], Parts[2], int.Parse(Parts[3]), Parts[4], Parts[5], Parts[6], Parts[7], ConvertStringToBool(Parts[8]), Parts[9]);
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
        public static void SmazatZvireZeSouboru(string Soubor, int ID)
        {
            List<Zvire> Zvirata = VypisZvireZeSouboru(Soubor);
            foreach (var zvire in Zvirata)
            {
                if (zvire.ID == ID)
                {
                    Zvirata.Remove(zvire);
                    break;
                }
            }
            foreach (var zvire in Zvirata)
            {
                ZapisZvireDoSouboru(Soubor, zvire);
            }
        }

        public static List<Zvire> FiltrZviratVek(string Soubor, int Vek, string OperaceSVekem)
        {
            List<Zvire> Zvirata = VypisZvireZeSouboru(Soubor);
            List<Zvire> FiltrovanaZvirata = new List<Zvire>();

            switch (OperaceSVekem)
            {
                case "<":
                    foreach (var zvire in Zvirata)
                    {
                        if (zvire.Vek < Vek)
                        {
                            FiltrovanaZvirata.Add(zvire);
                        }
                    }
                    break;
                case ">":
                    foreach (var zvire in Zvirata)
                        {
                            if (zvire.Vek > Vek)
                            {
                                FiltrovanaZvirata.Add(zvire);
                            }
                        }
                    break;
                case "=":
                    foreach (var zvire in Zvirata)
                    {
                        if (zvire.Vek == Vek)
                        {
                            FiltrovanaZvirata.Add(zvire);
                        }
                    }
                    break;

                default:
                    return FiltrovanaZvirata;
            }
            return FiltrovanaZvirata;
        }
        public static List<Zvire> FiltrZviratDruh(string Soubor, string Druh)
        {
            List<Zvire> Zvirata = VypisZvireZeSouboru(Soubor);
            List<Zvire> FiltrovanaZvirata = new List<Zvire>();

            foreach (var zvire in Zvirata)
            {
                if (zvire.Druh.ToLower() == Druh.ToLower())
                {
                    FiltrovanaZvirata.Add(zvire);
                }
            }
            return FiltrovanaZvirata;
        }
        public static List<Zvire> FiltrZviratJmeno(string Soubor, string Jmeno)
        {
            List<Zvire> Zvirata = VypisZvireZeSouboru(Soubor);
            List<Zvire> FiltrovanaZvirata = new List<Zvire>();

            foreach (var zvire in Zvirata)
            {
                if (zvire.Jmeno.ToLower() == Jmeno.ToLower())
                {
                    FiltrovanaZvirata.Add(zvire);
                }
            }
            return FiltrovanaZvirata;
        }
    }
}

