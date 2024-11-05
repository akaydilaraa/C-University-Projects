using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaHesabiSinifi
{

    class BankaHesabi
    {
       public string HesapNumarasi { get; private set; }
       private decimal Bakiye { get; set; }

        public BankaHesabi(string hesapNumarasi,decimal ilkBakiye )
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;

        }
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Güncel Bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yatırılacak miktar sıfırdan büyük olmalıdır.");
            }
        }

        public void ParaCek(decimal miktar)
        {
            if(miktar>0 && miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel Bakiye: {Bakiye} TL");
            }else if(miktar>Bakiye){
                Console.WriteLine("Yetersiz bakiye");
            }
            else
            {
                Console.WriteLine("0'dan büyük bir miktar giriniz");
            }
        }

        public decimal GetBakiye()
        {
            return Bakiye;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankaHesabi hesap1 = new BankaHesabi("12345", 1500m);
            Console.WriteLine("İlk bakiyeniz " + hesap1.GetBakiye());
            hesap1.ParaCek(500m);
            hesap1.ParaYatir(500m);
            hesap1.ParaCek(1800m);

            Console.WriteLine("Son bakiye " + hesap1.GetBakiye());
            Console.Read();
        }
    }
}
