using System;

namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Введите число a (пи = pi)");
            string aInput = Console.ReadLine();   //вводим переменную a
            Console.WriteLine("Введите число b (пи = pi)");
            string bInput = Console.ReadLine();   //вводим переменную b
            Console.WriteLine("Введите число c (пи = pi)");
            string cInput = Console.ReadLine();   //вводим переменную c

            //создаем сами паременные
            double a, b, c;

            //проверка числа a 
            if (aInput.ToLower() == "pi") { a = Math.PI; }
            else { a = double.Parse(aInput); }
            //проверка числа b
            if (bInput.ToLower() == "pi") { b = Math.PI; }
            else { b = double.Parse(bInput); }
            //проверка числа c
            if (cInput.ToLower() == "pi") { c = Math.PI; }
            else { c = double.Parse(cInput); }

            double num1, num2, result;   // создаем перемнные (числитель, знаменатель и результат)

            num1 = (Math.Pow(b + (Math.Pow(a - 1, 1 / 3.0)), 1 / 4.0));   //вычисление числителя 
            num2 = (Math.Abs(a - b)) * (Math.Pow(Math.Sin(c), 2) + Math.Tan(c));   //вычисление знаменателя
            result = num1 / num2;   //деление числителя на знаменатель

            Console.WriteLine("Результат: " + result);   //показ результата

        }
    }
}