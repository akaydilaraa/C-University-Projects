using System;
using System.Collections.Generic;

namespace IslemOnceligiProje
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lütfen bir matematiksel ifade girin (örneğin, 3 + 4 * 2 / (1 - 5) ^ 2):");
            string expression = Console.ReadLine();

            try
            {
                double result = EvaluateExpression(expression);
                Console.WriteLine("Sonuç: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static double EvaluateExpression(string expression)
        {
            // Boşlukları kaldır
            expression = expression.Replace(" ", "");

            // İfadenin öncelikli olarak değerlendirilmesi için bir yığın kullanacağız
            var values = new Stack<double>();
            var ops = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                // Eğer karakter sayı ise
                if (char.IsDigit(expression[i]) || expression[i] == '.')
                {
                    string buffer = "";

                    // Çok haneli veya ondalıklı sayılar için döngü
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        buffer += expression[i++];
                    }
                    values.Push(double.Parse(buffer));
                    i--; // Son karakter için geri git
                }
                else if (expression[i] == '(')
                {
                    ops.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    while (ops.Count > 0 && ops.Peek() != '(')
                    {
                        values.Push(ApplyOperation(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop(); // Parantezi çıkart
                }
                else if (IsOperator(expression[i]))
                {
                    while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(expression[i]))
                    {
                        values.Push(ApplyOperation(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Push(expression[i]);
                }
            }

            while (ops.Count > 0)
            {
                values.Push(ApplyOperation(ops.Pop(), values.Pop(), values.Pop()));
            }

            return values.Pop();
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
            }
            return 0;
        }

        static double ApplyOperation(char op, double b, double a)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                case '^': return Math.Pow(a, b);
            }
            throw new NotSupportedException($"Operatör desteklenmiyor: {op}");
        }
    }
}
