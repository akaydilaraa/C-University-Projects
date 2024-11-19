using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; set; }

        public Sirket(string ad, string konum)
        {
            Ad = ad;
            Konum = konum;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            calisan.SirketAtama(this); // Çalışana şirket atanır
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public DateTime YayinTarih { get; set; }
        public Sirket Sirket { get; private set; }

        public Calisan(string ad, DateTime yayinTarih)
        {
            Ad = ad;
            YayinTarih = yayinTarih;
        }

        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this))
            {
                sirket.CalisanEkle(this); // Şirketin çalışan listesinde yoksa eklenir
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sirket sirket1 = new Sirket("ABC Teknoloji", "İstanbul");
            Calisan calisan1 = new Calisan("Ali Veli", new DateTime(2020, 1, 15));

            sirket1.CalisanEkle(calisan1);

            Console.WriteLine($"{sirket1.Ad} adlı şirketin çalışanları:");
            foreach (var calisan in sirket1.Calisanlar)
            {
                Console.WriteLine($"- {calisan.Ad}, Yayın Tarihi: {calisan.YayinTarih.ToShortDateString()}");
            }

            Console.WriteLine($"\n{calisan1.Ad} adlı çalışanın şirketi: {calisan1.Sirket.Ad}");
            Console.Read();
        }
    }
}
