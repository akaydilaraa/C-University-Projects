using System; // Temel giriş-çıkış işlemleri için gerekli kütüphane
using System.Collections.Generic; // List veri yapısı için gerekli kütüphane
using System.Linq; // LINQ metodları (Average gibi) için gerekli kütüphane

namespace OrtalamaMedyanHesabı
{
    class Program
    {
        static void Main(string[] args) // Programın ana giriş noktası
        {
            List<int> sayilar = new List<int>(); // Kullanıcının girdiği sayıları saklamak için bir liste tanımlıyoruz
            int girdi; // Kullanıcıdan alınan sayıları geçici olarak tutacak değişken

            // Kullanıcıdan pozitif tam sayılar alıyoruz (0 girilene kadar devam eder)
            Console.WriteLine("Pozitif tam sayılar girin (0 girince işlemi bitirir):");
            do // Döngü başlatılır (en az bir kez çalışır)
            {
                Console.Write("Sayı: "); // Kullanıcıdan bir sayı girmesini ister
                string input = Console.ReadLine(); // Kullanıcıdan girdi alır

                // Girdiyi tamsayıya dönüştürmeyi deneriz
                if (int.TryParse(input, out girdi)) // Eğer girdi tamsayıya dönüşebiliyorsa
                {
                    if (girdi > 0) // Eğer girilen sayı 0'dan büyükse
                        sayilar.Add(girdi); // Sayıyı listeye ekler
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir pozitif tam sayı girin."); // Geçersiz giriş uyarısı
                }

            } while (girdi != 0); // Kullanıcı 0 girene kadar döngü devam eder

            // Eğer hiç geçerli sayı girilmemişse uyarı gösterir ve programı sonlandırır
            if (sayilar.Count == 0)
            {
                Console.WriteLine("Hiç sayı girilmedi."); // Uyarı mesajı
                return; // Program sonlanır
            }

            // Ortalama hesaplanır (LINQ Average metodu ile)
            double ortalama = sayilar.Average();
            Console.WriteLine($"Ortalama: {ortalama:F2}"); // Ortalama ekrana yazdırılır (2 ondalık basamak ile)

            // Medyan hesaplamak için listeyi küçükten büyüğe sıralarız
            sayilar.Sort();
            double medyan = MedyanHesapla(sayilar); // Medyanı hesaplamak için fonksiyon çağrılır
            Console.WriteLine($"Medyan: {medyan}"); // Medyan ekrana yazdırılır

            // Program sona ermeden önce kullanıcıdan bir tuşa basmasını bekler
            Console.WriteLine("Devam etmek için bir tuşa basın..."); // Kullanıcıya mesaj
            Console.ReadKey(); // Kullanıcının bir tuşa basmasını bekler
        }

        // Medyan hesaplayan yardımcı fonksiyon
        static double MedyanHesapla(List<int> dizi) // Listeyi parametre olarak alır
        {
            int n = dizi.Count; // Listenin eleman sayısını alır

            if (n % 2 == 1) // Eğer eleman sayısı tekse
                return dizi[n / 2]; // Ortadaki elemanı döndürür
            else // Eğer eleman sayısı çiftse
                return (dizi[n / 2 - 1] + dizi[n / 2]) / 2.0; // Ortadaki iki elemanın ortalamasını döndürür
        }
    }
}


