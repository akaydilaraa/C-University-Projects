using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresDefteriSinifi
{

    class AdresBilgisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }

        public AdresBilgisi(string ad,string soyad,string telefonnumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonnumarasi;

        }

        public string KisiBilgisi()
        {
            return $"Tam Adı: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AdresBilgisi kisi1 = new AdresBilgisi("Dilara", "Akay", "05555555555");
            Console.WriteLine(kisi1.KisiBilgisi());
            Console.Read();
        }
    }
}
