using System;

namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] array = new char[9][]; //создание ступенчатого массива
            Random rnd = new Random(); //рандом

            Console.WriteLine("Ступенчатый массив:"); 
            for (int i = 0; i < 9; i++)
            {
                array[i] = new char[rnd.Next(6, 41)]; //от 6 до 40 символов в строке
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = (char)rnd.Next(65, 91); //случайное число от 65 до 90 и преобразование в символ от 'A' до 'Z'
                    Console.Write(array[i][j] + " "); //вывод значения элемента массива
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Массив с последними элементы каждой строки: ");
            char[] last = new char[array.Length]; //создаем одномерный массив
            for (int i = 0; i < array.Length; i++)
            {
                last[i] = array[i][array[i].Length - 1];
            }
            foreach (char last2 in last)
            {
                Console.WriteLine(last2);
            }
            Console.WriteLine();

            int[] maxArray = new int[array.Length]; //создаем массив для максимальных значений строки 
            for (int i = 0; i < array.Length; i++)
            {
                int max1 = int.MinValue; //минимальное допустимое значение
                foreach (int num in array[i])
                {
                    if (num > max1) 
                    {
                        max1 = num;
                    }
                }
                maxArray[i] = max1;
            }
            Console.WriteLine("Массив с максимальными значениями строки ступенчатого массива: ");
            foreach (int num in maxArray)
            {
                Console.Write((char)num + " "); //вывод значения 
            }
            Console.WriteLine();

            Console.WriteLine("\nРеверс массива: ");
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]); //реверсивует массив
                Console.WriteLine(String.Join(" ", array[i]));
            }
            Console.WriteLine();
        }
    }
}
    

    

   