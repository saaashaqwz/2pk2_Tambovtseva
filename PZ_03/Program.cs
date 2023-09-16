using System;
namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double discont, price; //присваиваем переменные
            Console.WriteLine("Введите цену Вашего товара");
            int a = Convert.ToInt32(Console.ReadLine()); //присваиваем переменную (скидка)
            Console.WriteLine("Введите день покупки товара");
            string day = Console.ReadLine(); //вводим день недели
            switch (day)
            {                
                case "Понедельник": case "Вторник": case "Среда": case "Четверг": case "Пятница": //если будние дни
                    discont = ((double)a / 100) * 5; //счет скидки 5%
                    price = a - discont; //вычисление цены со скидкой
                    Console.WriteLine("Скидка составляет: " + Math.Round(discont, 1));
                    Console.WriteLine("Цена товара со скидкой: " + Math.Round(price, 1));
                    break;
                case "Суббота": case "Воскресенье": //если выходные
                    discont = ((double)a / 100) * 10; //счет скидки 10%
                    price = a - discont; //вычисление цены со скидкой
                    Console.WriteLine("Скидка составляет: " + Math.Round(discont, 1));
                    Console.WriteLine("Цена товара со скидкой: " + Math.Round(price, 1)); 
                break;
                default:
                    Console.WriteLine("Неккоректные данные"); //выводит если данные введены не правильно
                break;
                }
            }
        }
    }