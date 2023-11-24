using System;

namespace PZ_11
{
    internal class Program
    {
        static void DigitCountSum(int K, out int C, out int S)
        {
            char[] num = K.ToString().ToCharArray();
            C = num.Length; //кол-во символов
            S = 0;
            foreach (char c in num)
            {
                S += Int32.Parse(c.ToString()); //преобразование
            }
        }

        static void Main(string[] args)
        {
            int K = Convert.ToInt32(Console.ReadLine());
            DigitCountSum(K, out int C, out int S);
            Console.WriteLine("Количество чисел: " + C);
            Console.WriteLine("Сумма всех чисел: " + S);
        }
    }
}