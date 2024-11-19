using System;
using System.Globalization;

namespace Odev6._2
{
    class Urun
    {
        public string Ad { get; set; }
        private int fiyat;

        public Urun(string ad, int fiyat)
        {
            Ad = ad;
            this.fiyat = fiyat;
        }

        public int GetFiyat() => fiyat;
        public void SetFiyat(int yeniFiyat) => fiyat = yeniFiyat;
        public void UrunBilgisiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {fiyat}");
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }

        public Siparis(DateTime tarih, decimal toplam)
        {
            Tarih = tarih;
            Toplam = toplam;
        }

        public void SiparisBilgisiYazdir()
        {
            Console.WriteLine($"Sipariş Tarihi: {Tarih}, Toplam: {Toplam:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Urun urun1 = new Urun("Televizyon", 15000);
            urun1.UrunBilgisiYazdir();

            Siparis siparis1 = new Siparis(DateTime.Now, 15000);
            siparis1.SiparisBilgisiYazdir();
            Console.Read();
        }
    }
}
