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
                merkozesek.Add(new Meccs(adat[0], adat[1],Convert.ToInt32(adat[2]), Convert.ToInt32(adat[3]), adat[4], adat[5]));
            }
        }
        static void HarmadikFeladat()
        {
            //select-es megoldás
            var hazai = from m in merkozesek where m.Hazai == "Real Madrid" select m;
            int hazaiDb = hazai.ToList().Count;

            var idegen = from m in merkozesek where m.Idegen == "Real Madrid" select m;
            int idegenDb = idegen.ToList().Count;

            Console.WriteLine($"Real Madrid: Hazai: {hazaiDb}, Vendég: {idegenDb}");

            //if-es megoldása

            //int hazai = 0;
            //int vendeg = 0;
            //foreach (var i in merkozesek)
            //{
            //    if (i.Hazai=="Real Madrid")
            //    {
            //        hazai++;
            //    }
            //    else if (i.Idegen=="Real Madrid")
            //    {
            //        vendeg++;
            //    }

            //}
            // Console.WriteLine($"Real Madrid: Hazai: {hazai}, Vendég: {vendeg}");

        }
        static void 
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            Console.ReadKey();
        }
    }
}
