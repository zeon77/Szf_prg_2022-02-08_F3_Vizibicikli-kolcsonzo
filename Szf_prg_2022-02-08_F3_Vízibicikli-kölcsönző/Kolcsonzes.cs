using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizibicikliKolcsonzo
{
    //2.
    class Kolcsonzes
    {
        public string Név { get; set; }
        public char JAzon { get; set; }
        public TimeSpan Tól { get; set; }
        public TimeSpan Ig { get; set; }

        //3.
        public Kolcsonzes(string sor)
        {
            string[] t = sor.Split(';');
            Név = t[0];
            JAzon = char.Parse(t[1]);
            Tól = new TimeSpan(int.Parse(t[2]), int.Parse(t[3]), 0);
            Ig = new TimeSpan(int.Parse(t[4]), int.Parse(t[5]), 0);
        }
    }
}
