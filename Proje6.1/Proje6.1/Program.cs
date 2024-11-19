using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje6._1
{

    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;

        }
        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
        }

        public void BilgiGoster()
        {
            Console.WriteLine($"Çalışan Adı: {Ad}");
            Console.WriteLine($"Pozisyon: {Pozisyon}");
            if (Departman != null)
            {
                Console.WriteLine($"Departman Adı: {Departman.Ad}");
                Console.WriteLine($"Departman Lokasyonu: {Departman.Lokasyon}");
            }
            else
            {
                Console.WriteLine("Bu çalışan henüz bir departmana atanmadı.");
            }
        }
    }



    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }
        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Departman d1 = new Departman("DepartmanAdı", "DepartmanLokasyonu");

            Calisan c1 = new Calisan("Ali", "Müdür");
            c1.DepartmanAtama(d1);
            Console.WriteLine("departman atandı");
            Console.WriteLine("Çalışan bilgileri:");
            c1.BilgiGoster();
            Console.Read();
        }

    }
}
