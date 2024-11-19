using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev6._3
{
    class Musteri
    {
        public string Ad { get; set; }
        public List<Siparis> Siparisler { get; set; }

        public Musteri(string ad)
        {
            Ad = ad;
            Siparisler = new List<Siparis>();
        }

        public void SiparisEkle(Siparis siparis)
        {
            Siparisler.Add(siparis);
        }

        public void MusteriBilgisiYazdir()
        {
            Console.WriteLine($"Müşteri Adı: {Ad}");
            Console.WriteLine("Siparişler:");
            foreach (var siparis in Siparisler)
            {
                siparis.SiparisBilgisiYazdir();
            }
        }
    }

    class Urun
    {
        public string Ad { get; set; }
        private int fiyat; // Fiyat özelliği private

        public Urun(string ad, int fiyat)
        {
            Ad = ad;
            this.fiyat = fiyat;
        }

        public int GetFiyat() => fiyat; // Fiyatı almak için getter metodu
        public void SetFiyat(int yeniFiyat) => fiyat = yeniFiyat; // Fiyatı ayarlamak için setter metodu

        public void UrunBilgisiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {fiyat}");
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }
        public List<Urun> Urunler { get; set; }

        public Siparis(DateTime tarih)
        {
            Tarih = tarih;
            Urunler = new List<Urun>();
            Toplam = 0;
        }

        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
            Toplam += urun.GetFiyat();
        }

        public void SiparisBilgisiYazdir()
        {
            Console.WriteLine($"Sipariş Tarihi: {Tarih}, Toplam Tutar: {Toplam:C}");
            Console.WriteLine("Ürünler:");
            foreach (var urun in Urunler)
            {
                Console.WriteLine($"- {urun.Ad}, Fiyat: {urun.GetFiyat()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Musteri musteri1 = new Musteri("Ahmet");
            Urun urun1 = new Urun("Telefon", 7000);
            Urun urun2 = new Urun("Kulaklık", 500);

            Siparis siparis1 = new Siparis(DateTime.Now);
            siparis1.UrunEkle(urun1);
            siparis1.UrunEkle(urun2);

            musteri1.SiparisEkle(siparis1);

            musteri1.MusteriBilgisiYazdir();
            Console.Read();
        }
    }
}
