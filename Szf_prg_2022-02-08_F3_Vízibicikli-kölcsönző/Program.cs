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
                Console.WriteLine($"Nem volt ilyen nevű kölcsönző...");
            }
            else
            {
                Console.WriteLine($"\t{név} kölcsönzései:");
                list.ForEach(k => Console.WriteLine($"\t{k.Tól.ToString(@"hh\:mm")}-{k.Ig.ToString(@"hh\:mm")}"));
            }

        }
    }
}
