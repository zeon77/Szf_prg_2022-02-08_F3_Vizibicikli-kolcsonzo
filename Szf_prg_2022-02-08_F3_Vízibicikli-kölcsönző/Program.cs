using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VizibicikliKolcsonzo
{
    class Program
    {
        static void Main(string[] args)
        {
            //4.
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
            foreach (var sor in File.ReadAllLines("kolcsonzesek.txt").Skip(1))
            {
                kolcsonzesek.Add(new Kolcsonzes(sor));
            }

            //5.
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzesek.Count}");

            //6.
            Console.Write($"6. feladat: Kérek egy nevet: ");
            string név = Console.ReadLine();

            var list = kolcsonzesek.Where(k => k.Név == név).ToList();
            if (list.Count == 0)
            {
                Console.WriteLine($"\tNem volt ilyen nevű kölcsönző...");
            }
            else
            {
                Console.WriteLine($"\t{név} kölcsönzései:");
                list.ForEach(k => Console.WriteLine($"\t{k.Tól.ToString(@"hh\:mm")}-{k.Ig.ToString(@"hh\:mm")}"));
            }

            //7.
            Console.Write($"7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string s = Console.ReadLine();
            TimeSpan időpont = new TimeSpan(int.Parse(s.Split(':')[0]), int.Parse(s.Split(':')[1]), 0);
            list = kolcsonzesek.Where(k => k.Tól <= időpont && időpont <= k.Ig).ToList();
            if (list.Count == 0)
            {
                Console.WriteLine($"\tA megadott időpontban egy jármű sem volt vízen...");
            }
            else
            {
                Console.WriteLine($"A vízen lévő járművek: ");
                list.ForEach(k => Console.WriteLine($"\t{k.Tól.ToString(@"hh\:mm")}-{k.Ig.ToString(@"hh\:mm")} : {k.Név}"));
            }

            //8.
            int bevétel = 0;
            foreach (var k in kolcsonzesek)
            {
                bevétel += (int)Math.Ceiling((k.Ig - k.Tól).TotalMinutes / 30) * 2400;
            }
            Console.WriteLine($"8. feladat: A napi bevétel: {bevétel:C0}");

            //9. 
            StreamWriter sw = new StreamWriter("F.txt");
            list = kolcsonzesek.Where(k => k.JAzon == 'F').ToList();
            foreach (var k in list)
            {
                sw.WriteLine($"{k.Tól.ToString(@"hh\:mm")}-{k.Ig.ToString(@"hh\:mm")} : {k.Név}");
            }
            sw.Close();

            //10.
            Console.WriteLine($"10. feladat: Statisztika");
            kolcsonzesek
                .GroupBy(k => k.JAzon)
                .Select(gr => new { JAzon = gr.Key, db = gr.Count() })
                .OrderBy(s => s.JAzon)
                .ToList()
                .ForEach(s => Console.WriteLine($"\t{s.JAzon} - {s.db}"));
        }
    }
}
