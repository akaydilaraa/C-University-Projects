using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSinifi
{

    class Urun
    {
        public string Ad { get; private set; }
        public decimal Fiyat { get; private set; }
        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if(value>=0 && value <= 50)
                {
                    indirim = value;
                }
                else
                {
                    Console.WriteLine("İndirim 0 ve 50 arasında olmalıdır");

                }
            }
        }

        public Urun(string isim,decimal fiyat)
        {
            Ad = isim;
            Fiyat = fiyat;
            indirim = 0;
        }

        public decimal IndirimliFiyat()
        {
            decimal indirimMiktari = Fiyat * indirim / 100;
            return Fiyat - indirimMiktari;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Urun urun1 = new Urun("pc", 10000m);

            urun1.Indirim = 30;
            Console.WriteLine("Ürünün adı: " + urun1.Ad);
            Console.WriteLine("Ürünün ilk fiyatı: " + urun1.Fiyat);
            Console.WriteLine("Ürünün indirimli fıyatı: " + urun1.IndirimliFiyat());

            Console.Read();

        }
    }
}
