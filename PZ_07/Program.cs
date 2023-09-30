using System;

namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[,] array = new int[n, m]; //двумерный массив
            Random rnd = new Random(); //рандом

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(1, 100); //диапазон случайных чисел
                }
            }

            for (int i = 0; i < n; i++)  //вывод массива
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            double[] averages = new double[n];  //массив среднего арифметических числа

            for (int i = 0; i < n; i++) //вычисление среднего арифметического каждой строки
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += array[i, j]; //вычисление суммы чисел в строке
                }
                averages[i] = Math.Round((double)sum / m,2); //вычисление и округление арифметического числа до сотых
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Среднее арифметическое строки {0}: {1}", i + 1, averages[i]); //вывод 
            }
        }
    }
}
    