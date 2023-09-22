using System;

namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine("Число  Квадрат  Куб");

            do
            {
                double a = Math.Pow(i, 2);
                double b = Math.Pow(i, 3);
                Console.WriteLine($"{i,-7} {a,-7} {b}");
                i++;
            }
            while (i <= 10);

            Console.ReadLine();
        }
    }
}