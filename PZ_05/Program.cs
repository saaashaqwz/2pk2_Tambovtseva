using System;

namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1; //счетчик цикла
            Console.WriteLine("Число  Квадрат  Куб");

            do
            {
                double a = Math.Pow(i, 2); //выполнение действия возведения в квадрат
                double b = Math.Pow(i, 3); //выполнение действия возведение в куб
                Console.WriteLine($"{i,-7 /*сдвиг вправо*/} {a,-7 /*сдвиг вправо*/} {b}"); //показ итога
                i++; //увеличивает на 1
            }
            while (i <= 10); //выполение цикла до числа 11

            Console.ReadLine();
        }
    }
}
