using System;
using System.Collections.Generic;

namespace ZamanYolcusu
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now; // Bugünün tarihini al
            int startYear = 2000; // Başlangıç yılı
            int endYear = 3000; // Bitiş yılı
            List<string> validDates = new List<string>(); // Geçerli tarihler için liste

            // Tüm yılları kontrol et
            for (int year = startYear; year <= endYear; year++)
            {
                // Tüm ayları kontrol et
                for (int month = 1; month <= 12; month++)
                {
                    // O ayın gün sayısını al
                    int daysInMonth = DateTime.DaysInMonth(year, month);

                    // Tüm günleri kontrol et
                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        // Mevcut tarih
                        DateTime date = new DateTime(year, month, day);

                        // Şu andan sonraki tarih mi?
                        if (date <= today)
                            continue; // Eğer geçmişteyse atla

                        // Tarih koşullarını kontrol et
                        if (IsValidDate(day, month, year))
                        {
                            validDates.Add(date.ToString("dd.MM.yyyy")); // Geçerli tarihi listeye ekle
                        }
                    }
                }
            }

            // Geçerli tarihleri yazdır
            Console.WriteLine("Cihazın kabul ettiği geçerli tarihler:");
            foreach (var validDate in validDates)
            {
                Console.WriteLine(validDate); // Her bir geçerli tarihi yazdır

            }
            Console.Read();

        }

        // Tarih koşullarını kontrol eden fonksiyon
        static bool IsValidDate(int day, int month, int year)
        {
            return IsPrime(day) && IsEvenDigitSum(month) && IsYearValid(year); // Tüm koşulları kontrol et
        }

        // Asal sayı kontrolü yapan fonksiyon
        static bool IsPrime(int number)
        {
            if (number < 2) return false; // 2'den küçük sayılar asal değildir
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false; // Bölünebiliyorsa asal değildir
            }
            return true; // Asaldır
        }

        // Ay sayısının basamaklarının toplamının çift olup olmadığını kontrol eden fonksiyon
        static bool IsEvenDigitSum(int month)
        {
            int sum = 0;
            while (month > 0)
            {
                sum += month % 10; // Basamağı al ve toplama ekle
                month /= 10; // Bir sonraki basamağa geç
            }
            return sum % 2 == 0; // Toplam çiftse true döndür
        }

        // Yıl sayısının rakamlar toplamının o yılın dörtte birinden küçük olup olmadığını kontrol eden fonksiyon
        static bool IsYearValid(int year)
        {
            int sum = 0;
            int originalYear = year; // Yılı sakla
            while (year > 0)
            {
                sum += year % 10; // Basamağı al ve toplama ekle
                year /= 10; // Bir sonraki basamağa geç
            }
            return sum < (originalYear / 4); // Toplam, yılın dörtte birinden küçükse true döndür
        }
    }
}




