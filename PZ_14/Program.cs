using System;

namespace PZ_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string before = "before.txt"; //исходный файл
            string after = "after.txt"; //файл, в котором будут записаны строки с числами
            
            try
            {
                using (StreamReader sr = new StreamReader(before)) //открывает исходный файл для чтения
                {
                    using (StreamWriter sw = new StreamWriter(after)) //открывает новый файл для записи
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null) //читает файл построчно
                        {
                            if (Numbers(line)) //проверяет, есть ли числа в строке
                            {
                                sw.WriteLine(line); //записывает строку в новый файл
                            }
                        }
                    }
                }
                Console.WriteLine("Файл был записан " + after);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так " + ex.Message);
            }
        }
        static bool Numbers(string line) //метод для проверки содержания чисел 
        {
            foreach (char l in line)
            {
                if (Char.IsDigit(l)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}