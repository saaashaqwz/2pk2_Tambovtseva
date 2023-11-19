using System;

namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку: "); //ввод первой строки
            string str1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку: "); //ввод второй строки
            string str2 = Console.ReadLine();
            if (Anagram(str1, str2)) //если строки являются анаграммами
            {
                Console.WriteLine("Строки являются анаграммами");
            }
            else //иначе
            {
                Console.WriteLine("Строки не являются анаграммами");
            }
            Console.ReadLine();
        }

        static bool Anagram(string str1, string str2) //Anagram проверяет, являются ли str1 и str2 анаграммами друг друга
        {
            if (str1.Length != str2.Length) //если длины строк не равны, то значение false 
            {
                return false;
            }
            int[] elements = new int[25]; //создаем массив для проверки элементов (букв)
            for (int i = 0; i < str1.Length; i++)
            {
                elements[str1[i] - 'а']++; //увеличивает значение элемента массива
                elements[str2[i] - 'а']--; //уменьшает значение элемента массива
            }
            for (int i = 0; i < 25; i++)
            {
                if (elements[i] != 0) //если хотя бы один элемент не равен нулю, то значение false
                {
                    return false; 
                }
            }
            return true; //если ни один из элементов не равен нулю, то после выполнения цикла будет выполнен true
        }
    }    
}
