using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace PolinomIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polinom işlemleri programına hoş geldiniz! Çıkmak için her iki polinomdan birine 'exit' yazabilirsiniz.");

            while (true)
            {
                Console.Write("Birinci polinomu girin: ");
                string poly1 = Console.ReadLine();
                if (poly1.ToLower() == "exit") break;

                Console.Write("İkinci polinomu girin: ");
                string poly2 = Console.ReadLine();
                if (poly2.ToLower() == "exit") break;

                var polyDict1 = ParsePolynomial(poly1);
                var polyDict2 = ParsePolynomial(poly2);

                var sumResult = AddPolynomials(polyDict1, polyDict2);
                var subResult = SubtractPolynomials(polyDict1, polyDict2);

                Console.WriteLine($"\nPolinomların Toplamı: {FormatPolynomial(sumResult)}");
                Console.WriteLine($"Polinomların Farkı: {FormatPolynomial(subResult)}\n");

                Console.WriteLine("Yeni polinomlar girmek için Enter'a basın veya çıkmak için 'exit' yazın.");
                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() == "exit") break;
            }

            Console.WriteLine("Programdan çıkmak için Enter'a basın.");
            Console.ReadLine();
        }
        static Dictionary<int, int> ParsePolynomial(string polynomial)
        {
            var polyDict = new Dictionary<int, int>();

            // Polinomu terimlere ayıran regex
            var matches = Regex.Matches(polynomial.Replace(" ", ""), @"([+-]?\d*)x\^?(\d*)|([+-]?\d+)");

            foreach (Match match in matches)
            {
                int coefficient = 1;
                int exponent = 0;

                // x terimlerini kontrol et
                if (!string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    string coefStr = match.Groups[1].Value;
                    if (coefStr == "+" || coefStr == "-") coefStr += "1";
                    coefficient = int.Parse(coefStr);
                }
                else if (!string.IsNullOrEmpty(match.Groups[3].Value)) // Sabit terim varsa
                {
                    coefficient = int.Parse(match.Groups[3].Value);
                }

                // Üsleri kontrol et
                if (match.Groups[2].Success && int.TryParse(match.Groups[2].Value, out int expValue))
                {
                    exponent = expValue;
                }
                else if (match.Groups[1].Success) // x var ama üs yoksa
                {
                    exponent = 1; // x teriminin üstü 1
                }

                // Polinomdaki ilgili terimi güncelle
                if (polyDict.ContainsKey(exponent))
                    polyDict[exponent] += coefficient;
                else
                    polyDict[exponent] = coefficient;
            }

            return polyDict;
        }

        static Dictionary<int, int> AddPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
        {
            var result = new Dictionary<int, int>(poly1);
            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] += term.Value;
                else
                    result[term.Key] = term.Value;
            }
            return result;
        }

        static Dictionary<int, int> SubtractPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
        {
            var result = new Dictionary<int, int>(poly1);
            foreach (var term in poly2)
            {
                if (result.ContainsKey(term.Key))
                    result[term.Key] -= term.Value;
                else
                    result[term.Key] = -term.Value;
            }
            return result;
        }

        static string FormatPolynomial(Dictionary<int, int> polyDict)
        {
            var terms = new List<string>();
            foreach (var term in polyDict)
            {
                int coefficient = term.Value;
                int exponent = term.Key;

                if (coefficient == 0) continue; // Sıfır katsayılı terimleri atla

                string termStr;

                if (exponent == 0)
                    termStr = $"{coefficient}";
                else if (exponent == 1)
                    termStr = $"{(coefficient == 1 ? "" : coefficient == -1 ? "-" : coefficient.ToString())}x";
                else
                    termStr = $"{(coefficient == 1 ? "" : coefficient == -1 ? "-" : coefficient.ToString())}x^{exponent}";
                terms.Add(termStr);

            }


            return string.Join(" + ", terms).Replace("+ -", "- ");





        }
    }
}
