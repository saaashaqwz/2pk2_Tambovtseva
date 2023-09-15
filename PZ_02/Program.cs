using System;

namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a: ");
            int a = Convert.ToInt32(Console.ReadLine()); //целое число
            double c, x, y, t; //действительные числа
            Console.WriteLine("Введите число c: ");
            c = double.Parse(Console.ReadLine());
            if (c > 7.1)
            {
                x = Math.Cos(c + Math.Pow(a + Math.Pow(c, 2), 1 / 2.0 / 1.5)); //выполение действия если c > 7.1
            }
            else
            {
                x = Math.Sin(2 * c + a) + 14 * a; //выполение действия если c <= 7.1
            }
            if (x <= 0)
            {
                y = (Math.Abs(c) * a + 2.4 * Math.Cos(3 + a * c) + x); //выполение действия если x <= 0
            }
            else
            {
                y = (a * Math.Pow(x, 2) - 2 * c * x); //выполение действия если x > 0
            }
            t = (c + 11.2 * Math.Pow(a, 3)) / (2.7 * Math.Pow(x, 2) + 1.7 * Math.Pow(a, 2) + 3);
            Console.WriteLine("Ответ: " + Math.Round(t, 2)); //показ ответа
        }
    }
}