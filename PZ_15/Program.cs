namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь к каталогу:"); //ввод полного пути к каталогу
            string path = Console.ReadLine();

            int size = GetDirectorySize(path); //получение размера каталога в байтах
            Console.WriteLine($"Размер каталога: {Size(size)}");

            if (size > 10 * 1024 * 1024) //проверка на превышение размера 
            {
                DeleteLargestFile(path); //удаление самого большого файла 
            }
        }

        static int GetDirectorySize(string path)
        {
            int size = 0;

            foreach (string filePath in Directory.GetFiles(path)) //получение информации о каждом файле в каталоге
            {
                FileInfo fileInfo = new FileInfo(filePath);
                size += Convert.ToInt32(fileInfo.Length);
            }

            foreach (string subDir in Directory.GetDirectories(path)) //рекурсивный случай 
            {
                size += GetDirectorySize(subDir);
            }
            return size;
        }

        static void DeleteLargestFile(string path)
        {
            FileInfo largestFile = null;

            foreach (string filePath in Directory.GetFiles(path)) //информация о каждом файле 
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (largestFile == null || fileInfo.Length > largestFile.Length)
                {
                    largestFile = fileInfo;
                }
            }

            if (largestFile != null) //удаление самого большого файла 
            {
                Console.WriteLine($"Удаление файла {largestFile.Name}...");
                largestFile.Delete();
                Console.WriteLine("Файл успешно удален.");
            }
        }

        static string Size(int size)
        {
            string[] bytes = { "байт", "Кб", "Мб", "Гб", "Тб" };
            int index = 0;

            while (size >= 1024 && index < bytes.Length - 1)
            {
                size /= 1024;
                index++;
            }
            return $"{size} {bytes[index]}";
        }
    }
}