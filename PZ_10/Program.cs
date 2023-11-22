using System;

namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свой текст:");
            string text = Console.ReadLine();

            string[] sentences = text.Split(new char[] { '.', '!', '?' }); //разделение текста на предложения
            int[] word = new int[sentences.Length]; //создание массива для хранения кол-во слов в каждом предложении
            for (int i = 0; i < sentences.Length; i++)  //подсчет кол-во слов в каждом предложении
            {
                string sentence = sentences[i];
                string[] words = sentence.Trim().Split(new char[] { ' ' }); //разделение предложения на слова
                word[i] = words.Length; //сохранение кол-во слов
            }

            for (int i = 0; i < word.Length - 1; i++) //сортировка предложений по убыванию кол-во слов
            {
                for (int j = i + 1; j < word.Length; j++)
                {
                    if (word[i] < word[j])
                    {
                        int values = word[i]; //обмен значениями
                        word[i] = word[j];
                        word[j] = values;

                        string tradeSen = sentences[i]; //обмен предложениями
                        sentences[i] = sentences[j];
                        sentences[j] = tradeSen;
                    }
                }
            }
            Console.WriteLine("\nПредложения в порядке убывания количества слов:"); 
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}

