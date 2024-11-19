using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev6._9
{
    public class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }

        public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
        }
    }

    public class Kutuphane
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

        public Kutuphane(string ad)
        {
            Ad = ad;
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }

    // Kullanım
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane("Şehir Kütüphanesi");
            kutuphane.KitapEkle(new Kitap("Savaş ve Barış", "Tolstoy"));
            kutuphane.KitapEkle(new Kitap("1984", "George Orwell"));

            Console.WriteLine($"{kutuphane.Ad} içerisinde {kutuphane.Kitaplar.Count} kitap var.");
            Console.Read();
        }
    }
}
