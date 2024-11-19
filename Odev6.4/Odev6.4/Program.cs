using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev6._4
{
    class Doktor
    {
        public string Ad { get; set; }
        public string Branş { get; set; }
        public List<Hasta> Hastalar { get; set; }

        public Doktor(string ad, string branş)
        {
            Ad = ad;
            Branş = branş;
            Hastalar = new List<Hasta>();
        }

        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
            hasta.DoktorAtama(this); // Çift yönlü ilişkiyi kurmak için hasta tarafında da atama yapılıyor
        }
    }

    class Hasta
    {
        public string Ad { get; set; }
        public string TCKN { get; set; }
        public Doktor Doktor { get; private set; }

        public Hasta(string ad, string tckn)
        {
            Ad = ad;
            TCKN = tckn;
        }

        public void DoktorAtama(Doktor doktor)
        {
            Doktor = doktor;
            if (!doktor.Hastalar.Contains(this))
            {
                doktor.HastaEkle(this); // Doktor listesinde yoksa eklenir (çift yönlü koruma)
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Doktor doktor1 = new Doktor("Dr. Ahmet", "Kardiyoloji");
            Hasta hasta1 = new Hasta("Ali Yılmaz", "12345678901");

            doktor1.HastaEkle(hasta1);

            Console.WriteLine($"{doktor1.Ad} adlı doktorun hastaları:");
            foreach (var hasta in doktor1.Hastalar)
            {
                Console.WriteLine($"- {hasta.Ad}, TCKN: {hasta.TCKN}");
            }

            Console.WriteLine($"\n{hasta1.Ad} adlı hastanın doktoru: {hasta1.Doktor.Ad}");

            Console.Read();
        }
    }
}
