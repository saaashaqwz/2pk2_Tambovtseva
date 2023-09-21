using System;

namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1: "); //Вывести на экран построчно целые числа от -100 до 0 и с шагом равное 2.
            {
                for (int a = -100; a <= 0; a += 2)
                Console.WriteLine(a);
            }

            Console.WriteLine("\nЗадание №2: "); //Вывести на экран в одну строку 8 символов в алфавитном порядке, начиная с символа к (ru).
            {
                char x = 'к';
                for (int b = 0; b < 8; b++)
                {
                    char c = (char)(x + b);
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nЗадание №3: "); //Вывести на экран посимвольно 4 знака "#" в 8 строках.
            {
                int n, m;
                for (n = 0; n < 4; n++)
                {
                    for (m = 0; m < 8; m++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nЗадание №4: "); //Из диапазона от 0 до 200 вывести на экран значения, кратные 17, через пробел, используя один цикл. В конце вывести количество кратных чисел.
            {
                int y, k = 0;
                for (y = 0; y <= 200; y++)
                {
                    if (y % 17 == 0)
                    Console.Write(y + " "); k++;
                }
                Console.WriteLine("\nКоличество кратных чисел 17-ти: " + k);
            }
            Console.WriteLine("\nЗадание №5: "); //Выводить на экран значения 0 и 55, на каждом шаге итерации одну переменную инкрементировать, а вторую декрементировать до тех пор, пока разница между ними не будет равна (или меньше) 9
            {
                int i, j;
                for (i = 0, j = 55; j - i > 9; i++, j--)
                Console.WriteLine($"{i} {j}");
                Console.WriteLine($"Разница между чиселами равна {j - i}");

            }
        }
    }
}