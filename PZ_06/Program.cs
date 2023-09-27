namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine()); //присваиваем переменную

            double[] array = new double[size]; //массив из size (зависит от числа, который ввел пользаватель) вещ. чисел

            for (int i = 0; i < size; i++) 
            {
                Console.Write($"Введите элемент {i + 1}: "); 
                array[i] = double.Parse(Console.ReadLine()); //будет запрашивать столько элементов, сколько пользователь ввел для переменной size
            }

            double sum = 0; //переменная сумммы
            double p = 1; //переменная произведения

            foreach (double number in array) 
            {
                sum += number; //вычисление суммы чисел массива
                p *= number; //вычисление произведения числе массива
            }

            Console.WriteLine("Массив: ");
            foreach (double number in array) 
            {
                Console.Write(number + " "); //выводит элементы массива, которые ввел пользователь
            }

            Console.WriteLine();
            Console.WriteLine($"Сумма элементов: {sum}"); //выводит сумму чисел массива
            Console.WriteLine($"Произведение элементов: {p}"); //выводит произведение чисел массива

            Console.ReadLine();
        }
    }
}