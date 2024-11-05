using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSinifi
{
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }
    public class Kutuphane
    {
        private List<Kitap> Kitaplar = new List<Kitap>();
        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();

        }
        public void KitapEkle(Kitap YeniKitap)
        {
            this.Kitaplar.Add(YeniKitap);
            Console.WriteLine($"Kütüphaneye {YeniKitap.Ad} Kitabı Eklendi.");

        }
        public void KitaplariListele()
        {
            if (Kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede Kitap Bulunamadı.");
                return;
            }
            Console.WriteLine("Kütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"-{kitap.Ad}-{kitap.Yazar}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();
            Kitap k1 = new Kitap("Savaş ve Barış", "Lev Tolstoy");
            Kitap k2 = new Kitap("Suç ve Ceza", "Dostoyevski");
            Kitap k3 = new Kitap("Babam ve Oğlum", " Demirtaş Ceyhun");
            kutuphane.KitapEkle(k1);
            kutuphane.KitapEkle(k2);
            kutuphane.KitapEkle(k3);

            kutuphane.KitaplariListele();

            Console.Read();
        }
    }
}