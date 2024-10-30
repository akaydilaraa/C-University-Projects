using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kaç adet sayıyı sıralamak istersiniz ?");

            int sayiAdeti = int.Parse(Console.ReadLine());
            int[] girilensayilar = new int[sayiAdeti];
            Console.WriteLine("Sayıları giriniz");
            
            for(int i = 0; i < sayiAdeti; i++)
            {
                Console.Write($"Sayı {i+1} :");
                girilensayilar[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(girilensayilar);
            Console.WriteLine("\nSıralı Dizi: " + string.Join(", ", girilensayilar));

            // Kullanıcıdan aramak istediği sayıyı alıyoruz
            Console.Write("\nAramak istediğiniz sayıyı girin: ");
            int arananSayi = int.Parse(Console.ReadLine());

            // İkili arama algoritmasını kullanarak sayıyı arıyoruz
            int sonuc = BinarySearch(girilensayilar, arananSayi);

            // Sonucu ekrana yazdırıyoruz
            if (sonuc != -1)
            {
                Console.WriteLine($"\n{arananSayi} sayısı dizide bulundu (Index: {sonuc}).");
            }
            else
            {
                Console.WriteLine($"\n{arananSayi} sayısı dizide bulunamadı.");
            }
            Console.Read();
        }

        // İkili Arama Algoritması (Binary Search)
        static int BinarySearch(int[] dizi, int hedef)
        {
            int sol = 0, sag = dizi.Length - 1;

            while (sol <= sag)
            {
                int orta = (sol + sag) / 2;

                if (dizi[orta] == hedef)
                    return orta;
                else if (dizi[orta] < hedef)
                    sol = orta + 1;
                else
                    sag = orta - 1;
            }


            return -1; // Sayı bulunamazsa -1 döner


        }


    }
    
}
