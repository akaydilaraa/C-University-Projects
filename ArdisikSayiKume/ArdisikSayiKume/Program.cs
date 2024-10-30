using System; // Temel giriş-çıkış işlemleri için gerekli kütüphane
using System.Collections.Generic; // List veri yapısı için gerekli kütüphane

namespace ArdisikSayiKume
{
    class Program
    {
        static void Main(string[] args) // Programın ana giriş noktası
        {
            List<int> sayilar = new List<int>(); // Kullanıcının girdiği sayıları saklamak için bir liste tanımlıyoruz
            int girdi; // Kullanıcıdan alınan sayıları geçici olarak tutacak değişken

            // Kullanıcıdan tam sayılar alıyoruz (0 girilene kadar devam eder)
            Console.WriteLine("Tam sayılar girin (0 girince işlemi bitirir):");
            do // Döngü başlatılır (en az bir kez çalışır)
            {
                Console.Write("Sayı: "); // Kullanıcıdan bir sayı girmesini ister
                girdi = int.Parse(Console.ReadLine()); // Girilen değeri tamsayıya çevirir ve 'girdi' değişkenine atar

                if (girdi != 0) // Eğer girilen sayı 0 değilse
                    sayilar.Add(girdi); // Sayıyı listeye ekler

            } while (girdi != 0); // Kullanıcı 0 girene kadar döngü devam eder

            // Ardışık grupları tespit etmek için metodu çağırıyoruz
            List<string> ardışıkGruplar = ArdışıkGruplarıBul(sayilar); // Ardışık grupları bulur
            Console.WriteLine("Ardışık gruplar: " + string.Join(", ", ardışıkGruplar)); // Grupları ekrana yazdırır

            // Program sona ermeden önce kullanıcıdan bir tuşa basmasını bekler
            Console.WriteLine("Devam etmek için bir tuşa basın..."); // Kullanıcıya mesaj
            Console.ReadKey(); // Kullanıcının bir tuşa basmasını bekler
        }

        // Ardışık grupları tespit eden yardımcı fonksiyon
        static List<string> ArdışıkGruplarıBul(List<int> sayilar) // Listeyi parametre olarak alır
        {
            List<string> gruplar = new List<string>(); // Ardışık grupları saklamak için bir liste tanımlıyoruz
            if (sayilar.Count == 0) // Eğer liste boşsa
                return gruplar; // Boş liste döner

            // Listeyi küçükten büyüğe sıralıyoruz
            sayilar.Sort();

            int baslangic = sayilar[0]; // İlk sayıyı başlangıç olarak alıyoruz

            for (int i = 1; i < sayilar.Count; i++) // İlk elemandan başlıyoruz
            {
                // Eğer ardışık değilse, grup bitmiştir
                if (sayilar[i] != sayilar[i - 1] + 1)
                {
                    if (baslangic != sayilar[i - 1]) // Eğer grup birden fazla eleman içeriyorsa
                    {
                        gruplar.Add($"{baslangic}-{sayilar[i - 1]}"); // Grubu ekle (başlangıç-bitiş formatında)
                    }
                    // Tek elemanlı durumu burada göz ardı ediyoruz
                    baslangic = sayilar[i]; // Yeni grup için başlangıcı güncelle
                }
            }

            // Son grubu ekle
            if (baslangic != sayilar[sayilar.Count - 1]) // Eğer son grup birden fazla eleman içeriyorsa
            {
                gruplar.Add($"{baslangic}-{sayilar[sayilar.Count - 1]}"); // Grubu ekle (başlangıç-bitiş formatında)
            }

            return gruplar; // Grupları döndür
        }
    }
}



