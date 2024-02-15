using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PZ_18
{
    enum Tariff {Maxi, Standard, Economy}
    internal class Caller
    {
        private string fullName; //поле ФИО абонента
        public string FullName //свойства ФИО абонента
        {
            get => fullName; //при чтении выдает содержимое поля
            set //записывает в fullName не пустые строки или строку "Поле ФИО не может быть пустым"
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле ФИО не может быть пустым");
                }
                else
                {
                    fullName = value;
                }
            }
        }
        public Tariff Tariff { get; set; }
        public static int MaxCount { get; set; } //кол-во абонентов на тарифе макси 
        public static int StandardCount { get; set; } //кол-во абонентов на тарифе стандарт 
        public static int EconomyCount { get; set; } //кол-во абонентов на тарифе эконом
        public int Minutes { get; set; }
        public int InternetGb { get; set; } 
        public void MakeCall(int callDuration) //метод, совершения звонка
        {
            if (Minutes >= callDuration)
            {
                Minutes -= callDuration;
                Console.WriteLine($"Абонент {FullName} совершил звонок продолжительностью {callDuration} мин, остаток минут: {Minutes}");
            }
            else
            {
                Console.WriteLine("Недостаточно минут для звонка");
            }
        }
        public void TransferData(int dataMb) //метод, передачи инф-ции в каком-либо объеме
        {
            if (InternetGb >= dataMb / 1024)
            {
                InternetGb -= dataMb / 1024;
                Console.WriteLine($"Абонент {FullName} передал информацию в объеме {dataMb} Мб, остаток тарифа: {InternetGb} Гб");
            }
            else
            {
                Console.WriteLine("Недостаточно интернет-трафика для передачи данных");
            }
        }
        public static void GetCount() //вывод кол-ва абонентов на тарифах
        {
            Console.WriteLine($"Количество абонентов на тарифе Макси: {MaxCount}");
            Console.WriteLine($"Количество абонентов на тарифе Стандарт: {StandardCount}");
            Console.WriteLine($"Количество абонентов на тарифе Эконом: {EconomyCount}");
        }
        public Caller(string fullName, Tariff tariff)
        {
            FullName = fullName;
            Tariff = tariff;

            switch (tariff) 
            {
                case Tariff.Maxi:
                    Minutes = 1000;
                    InternetGb = 50;
                    break;
                case Tariff.Standard:
                    Minutes = 500;
                    InternetGb = 30;
                    break;
                case Tariff.Economy:
                    Minutes = 300;
                    InternetGb = 10;
                    break;
            }

            switch (tariff) 
            {
                case Tariff.Maxi:
                    MaxCount++;
                    break;
                case Tariff.Standard:
                    StandardCount++;
                    break;
                case Tariff.Economy:
                    EconomyCount++;
                    break;
            }
        }
    }
}
