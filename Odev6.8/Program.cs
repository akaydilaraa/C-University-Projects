using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev6._8
{
    public class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public string CalisanBilgi()
        {
            return $"{Ad}, {Pozisyon}";
        }
    }

    public class Sirket
    {
        public string Ad { get; set; }
        public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();

        public Sirket(string ad)
        {
            Ad = ad;
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }
    }

    // Kullanım
    class Program
    {
        static void Main(string[] args)
        {
            Sirket sirket = new Sirket("TechCorp");
            sirket.CalisanEkle(new Calisan("Ahmet", "Yazılım Mühendisi"));
            sirket.CalisanEkle(new Calisan("Ayşe", "Proje Yöneticisi"));

            Console.WriteLine($"{sirket.Ad} şirketinde {sirket.Calisanlar.Count} çalışan var.");
            Console.Read();
        }
    }
}
