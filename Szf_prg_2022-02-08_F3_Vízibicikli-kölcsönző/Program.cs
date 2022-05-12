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
        }
    }
}
