using System;

namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1: "); //С помощью рекурсии вычислите n-й член арифметической прогрессии, значения первого элемента a1=4 и шаг d=-2
            Console.Write("Введите число n: ");
            int n1 = Convert.ToInt32(Console.ReadLine()); 
            int result1 = Progression(n1);
            Console.WriteLine($"N-м элементом прогрессии является {result1}");

            Console.WriteLine("\nЗадание 2: "); //С помощью рекурсии вычислить n-й член геометрической прогрессии, значения первого элемента b1=5 и знаменатель прогрессии q=6
            Console.Write("Введите число n: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int result2 = Geometry(n2);
            Console.WriteLine($"N-м элементом прогрессии является {result2}");

            Console.WriteLine("\nЗадание 3: "); //Даны два целых числа A и В. Выведите все числа от A до B включительно, используя рекурсию, в порядке возрастания, если A < B, или в порядке убывания в противном случае
            Console.Write("Введите число А: ");
            int a3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b3 = Convert.ToInt32(Console.ReadLine());
            if (a3 < b3)
            {
                Console.WriteLine("Числа в порядке возрастания: ");
                Increasing(a3, b3);
            }
            else if (a3 > b3)
            {
                Console.WriteLine("Числа в порядке убывания: ");
                Decreasing(a3, b3);
            }
            else Console.WriteLine("Числа равны: ");

            Console.WriteLine("\nЗадание 4: "); //С помощью рекурсии Summ(int x) для введенного числа n вычислить сумму чисел от 1 до n
            Console.Write("Введите число n: ");
            int n4 = Convert.ToInt32(Console.ReadLine());
            int x = 1;
            int result4 = Summ(n4, x);
            Console.WriteLine($"Сумма чисел от 1 до {n4} равна {result4}");

        }

        static int Progression(int n) //метод нахождение арифметической прогрессии
        {
            if (n == 1) return 4; //базовый случай, если n равно 1, возвращаем первый элемент прогрессии

            else //рекурсивный случай
            {
                return Progression(n-1)-2;
            }
        }
        
        static int Geometry(int n) //метод нахождение геометрической прогрессии
        {
            if (n == 1) return 5; //базовый случай, если n равно 1, возвращаем первый элемент прогрессии

            else //рекурсивный случай
            {
                return Geometry(n-1)*6;
            }
        }

        static void Increasing(int A, int B) //метод: чисела в порядке возрастания
        {
            if (A <= B)
            {
                Console.WriteLine(A);
                A++;
                Increasing(A, B);
            }
        }
        static void Decreasing(int A, int B) //метод: чисела в порядке убывания
        {
            if (A >= B)
            {
                Console.WriteLine(A);
                A--;
                Decreasing(A, B);
            }
        }

        static int Summ(int n, int x) //метод вычисления сумму чисел от 1 до n
        {
            if (n == 1) return x; //базовый случай, если n равно 1, возвращаем первый элемент прогрессии
            else if (n < 1) return 0;
            else
            {
                return x + Summ(n - 1, x + 1);
            }
        }
    }
}

