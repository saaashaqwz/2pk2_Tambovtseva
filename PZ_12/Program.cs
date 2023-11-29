using System;
using System.Drawing;

namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
        int[] array = { 8, 13, 573, 125, 73, 9, 27, 6, 42 }; //произвольный массив
        int[] result = GetCube(array);
            foreach (int element in result)
            {
                Console.WriteLine($"Из числа {element} можно вычислить кубический корень");
            }
        }

        static int[] GetCube(params int[] array)
        {
            int count = 0;
            int[] result = new int[array.Length]; 
            foreach (int element in array)
            {
                double cube = Math.Pow(element, 1.0 / 3.0); //вычисление кубического корня
                if ((int)cube * (int)cube * (int)cube == element) 
                {
                    result[count] = element; //переменной result по индексу count будет значение element
                    count++;
                }
            }
            Array.Resize(ref result, count); //изменения размера массива result до размера count
            return result;
        }
    }
}

