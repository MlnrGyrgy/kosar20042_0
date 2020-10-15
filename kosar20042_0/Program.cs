using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar20042_0
{
    class Program
    {
        static List<Meccs> merkozesek = new List<Meccs>();
        static void MasodikFeladat()
        {
            StreamReader file = new StreamReader("eredmenyek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                string[] adat = file.ReadLine().Split(';');
                merkozesek.Add(new Meccs(adat[0], adat[1], Convert.ToInt32(adat[2]), Convert.ToInt32(adat[3]), adat[4], adat[5]));
            }
            file.Close();
        }
        static void HarmadikFeladat()
        {
            Console.WriteLine("3. Feladat");
            ////select-es megoldás
            //var hazai = from m in merkozesek where m.Hazai == "Real Madrid" select m;
            //int hazaiDb = hazai.ToList().Count;

            //var idegen = from m in merkozesek where m.Idegen == "Real Madrid" select m;
            //int idegenDb = idegen.ToList().Count;

            //Console.WriteLine($"Real Madrid: Hazai: {hazaiDb}, Vendég: {idegenDb}");

            //if-es megoldása

            int hazai = 0;
            int vendeg = 0;
            foreach (var i in merkozesek)
            {
                if (i.Hazai == "Real Madrid")
                {
                    hazai++;
                }
                else if (i.Idegen == "Real Madrid")
                {
                    vendeg++;
                }

            }
            Console.WriteLine($"Real Madrid: Hazai: {hazai}, Vendég: {vendeg}");
            Console.WriteLine();

        }
        static void NegyedikFeladat()
        {
            Console.WriteLine("4. Feladat");
            //if-es megoldás
            bool dontetlen=false;
            foreach (var i in merkozesek)
            {
                if (i.HPont == i.IPont)
                {
                    dontetlen = true;
                }
                else
                {
                    dontetlen = false;
                }
            }
            if (dontetlen==true)
            {
                Console.WriteLine("Volt döntetlen? Igen.");
            }
            else
            {
                Console.WriteLine("Volt döntetlen? Nem.");
            }
            Console.WriteLine();
        }
        static void OtodikFeladat()
        {
            Console.WriteLine("5.Feladat");
            var bar = from m in merkozesek where m.Hazai.Contains("Barcelona") select m;
            var barNev = bar.ToArray()[0].Hazai;
            Console.WriteLine(barNev);
            Console.WriteLine();
        }
        static void HatodikFeladat()
        {
            Console.WriteLine("6.Feladat");
            var november = from m in merkozesek where m.Idopont == "2004-11-21" select new{Hazai = m.Hazai, Idegen= m.Idegen, HP=m.HPont, IP=m.IPont};
            foreach (var i in november)
            {
                Console.WriteLine(i.Hazai+"-"+i.Idegen+" "+ i.HP+":" + i.IP);
            }
            Console.WriteLine();
        }
        static void HetedikFeladat()
        {
            Console.WriteLine("7.Feladat");
            var stadionok = from m in merkozesek orderby m.Hely group m by m.Hely into stadion select stadion;
            foreach (var i in stadionok)
            {
                Console.WriteLine(i.Key+ ":"+ i.Count());
            }
            Console.WriteLine();
        }
        static void NyolcadikFeladat()
        {
            Console.WriteLine("8.Feladat");
            Console.WriteLine("Fájlbaírás");
            StreamWriter file = new StreamWriter("meccsek.txt");           
            foreach (var i in merkozesek)
            {
                file.WriteLine(i.Eredmeny());
            }
            file.Close();
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();
            Console.ReadKey();
        }
    }
}
