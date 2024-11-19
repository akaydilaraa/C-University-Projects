using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev6._6
{

    class Ebeveyn
    {
        public string Ad { get; set; }
        public List<Cocuk> Cocuklar { get; set; }

        public Ebeveyn(string ad)
        {
            Ad = ad;
            Cocuklar = new List<Cocuk>();
        }

        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
            cocuk.EbeveynAtama(this); // Çocuğa ebeveyn atanır
        }
    }

    class Cocuk
    {
        public string Ad { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        public Cocuk(string ad)
        {
            Ad = ad;
        }

        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            if (!ebeveyn.Cocuklar.Contains(this))
            {
                ebeveyn.CocukEkle(this); // Ebeveynin çocuk listesinde yoksa eklenir
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ebeveyn ebeveyn1 = new Ebeveyn("Mehmet");
            Cocuk cocuk1 = new Cocuk("Ahmet");

            ebeveyn1.CocukEkle(cocuk1);

            Console.WriteLine($"{ebeveyn1.Ad} adlı ebeveynin çocukları:");
            foreach (var cocuk in ebeveyn1.Cocuklar)
            {
                Console.WriteLine($"- {cocuk.Ad}");
            }

            Console.WriteLine($"\n{cocuk1.Ad} adlı çocuğun ebeveyni: {cocuk1.Ebeveyn.Ad}");
            Console.Read();
        }
    }
}
