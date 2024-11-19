using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev6._7
{
    public class Oda
    {
        public string Boyut { get; set; }
        public string Tip { get; set; }

        public Oda(string boyut, string tip)
        {
            Boyut = boyut;
            Tip = tip;
        }
    }

    public class Ev
    {
        public string Ad { get; set; }
        public List<Oda> Odalar { get; set; } = new List<Oda>();

        public Ev(string ad)
        {
            Ad = ad;
        }

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }
    }

    // Kullanım
    class Program
    {
        static void Main(string[] args)
        {
            Ev ev = new Ev("Benim Evim");
            ev.OdaEkle(new Oda("12m²", "Yatak Odası"));
            ev.OdaEkle(new Oda("15m²", "Salon"));

            Console.WriteLine($"{ev.Ad} içerisinde {ev.Odalar.Count} oda var.");
            Console.Read();
        }
    }

}
