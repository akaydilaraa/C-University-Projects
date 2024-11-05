using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaSinifi
{

    class AracKiralama
    {
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        bool MusaitMi = true;


        public AracKiralama(string plaka,decimal gunlukucret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukucret;

        }

        public void AracKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine($"{Plaka} plakalı araç kiralandı");

            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı araç başka birisine kiralanmıştır");

            }
        }

        public void AraciTeslimEt()
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine($"{Plaka} plakalı araç teslim edildi");
            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı aracı teslim almamışsınız");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AracKiralama arac1 = new AracKiralama("60 DA 153", 2000m);
            Console.WriteLine($"Araç Plakası: {arac1.Plaka}");
            Console.WriteLine($"Günlük Ücret: {arac1.GunlukUcret} TL");

            arac1.AracKirala();
            arac1.AracKirala();
            arac1.AraciTeslimEt();
            arac1.AraciTeslimEt();

            Console.Read();

        }
    }
}
