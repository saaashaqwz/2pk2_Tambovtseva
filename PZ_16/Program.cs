namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта

        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        //предыдущие координаты игрока
        static int playerOldX = 0;
        static int playerOldY = 0;

        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static byte health = 5;  // количество аптечек   

        //параметры игрока 
        static int playerHealth = 50; //здоровье 
        static int playerStrong = 10; //урон 

        //параметры врага
        static int enemyHealth = 30; //здоровье 
        static int enemyStrong = 5; //урон 
        static int enemiesCount = 0; //подсчет врагов

        static int steps = 0; //подсчет шагов игрока
        static int oldSteps = 0; //проверка колво шагов до окончания баффа

        static void Main(string[] args)
        {
            StartGame();
            Move();
        }

        static void GenerationMap() //генерация карты с объектами
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в чередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли
        }

        static void Move() //перемещение
        {
            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                CheckBuff(); //проверка колво шагов до окончания баффа (если он используется)
                StatisticsGame(); //выводит на экран статистику игры
                Win();

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        steps++;
                        if (playerX == -1)
                        {
                            playerX = 23;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        playerX++;
                        steps++;
                        if (playerX == 24)
                        {
                            playerX = 0;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        playerY--;

                        steps++;
                        if (playerY == -1)
                        {
                            playerY = 24;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        playerY++;
                        steps++;
                        if (playerY == 25)
                        {
                            playerY = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Exit();
                        break;
                }

                switch (map[playerX, playerY]) //контактирование с объектами
                {
                    case 'E':
                        Fight();
                        break;
                    case 'B':
                        BuffUp();
                        map[playerX, playerY] = '_';
                        break;
                    case 'H':
                        playerHealth = 50;
                        map[playerX, playerY] = '_';
                        break;
                }

                Console.CursorVisible = false; //скрытный курсов

                //предыдущее положение игрока затирается
                map[playerOldX, playerOldY] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //обновленное положение игрока
                map[playerX, playerY] = 'P';
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');
                Console.ResetColor();
            }
        }

        static void StartGame() //старторый экран
        {
            Console.Clear();
            Console.SetCursorPosition(41, 13);
            Console.WriteLine("N - начать новую игру");
            Console.ResetColor();

            Console.SetCursorPosition(41, 14);
            Console.WriteLine("L - загрузить последнее сохранение");
            Console.ResetColor();
            Console.CursorVisible = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.L: //запускает последний сохраненный файл
                    Console.Clear();
                    LoadGame();
                    break;
                case ConsoleKey.N: //запускает новую игру
                    Console.Clear();
                    Basic();
                    GenerationMap();
                    break;
                default:
                    StartGame();
                    break;
            }
        }

        static void Basic() //параметры для новой игры
        {
            playerY = mapSize / 2;
            playerX = mapSize / 2;

            enemies = 10; //количество врагов
            buffs = 5; //количество усилений
            health = 5;  // количество аптечек   

            //параметры игрока 
            playerHealth = 50; //здоровье 
            playerStrong = 10; //урон 

            //параметры врага
            enemyHealth = 30; //здоровье 
            enemyStrong = 5; //урон 
            enemiesCount = enemies; //подсчет врагов

            steps = 0; //подсчет шагов игрока
            oldSteps = 0; //проверка колво шагов до окончания баффа
        }

        static void Fight() //логика обмена удара
        {
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.WriteLine('_');

            while (true)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('E');
                Thread.Sleep(100);
                Console.SetCursorPosition(playerY, playerX);
                Console.ResetColor();
                Console.Write('P');
                Thread.Sleep(50);
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                Console.Write('E');
                Thread.Sleep(50);

                if (enemyHealth <= 0)
                {
                    enemyHealth = 30;
                    enemiesCount++;
                    map[playerX, playerY] = '_';
                    break;
                }

                if (enemyHealth > 0)
                {
                    playerHealth = playerHealth - enemyStrong; //отнимание здоровья у игрока
                    enemyHealth = enemyHealth - playerStrong; //отнимание здоровья у врага
                }

                if (playerHealth <= 0) //если игрок побиг
                {
                    Death();
                    break;
                }
            }
        }

        static void BuffUp() //логика баффа (усиления)
        {
            oldSteps = steps;
            playerStrong *= 2;
        }

        static void CheckBuff() //подсчет колво шагов до окончания баффа (усиления)
        {
            if (playerStrong > 10)
            {
                if (20 - (steps - oldSteps) < 10)
                {
                    Console.SetCursorPosition(mapSize + 14, 18);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"До окончания действия бафа осталось: {20 - (steps - oldSteps)} шагов ");
                    Console.ResetColor();
                }
                else if (20 - (steps - oldSteps) % 2 != 0)
                {
                    Console.SetCursorPosition(mapSize + 14, 18);
                    Console.WriteLine($"До окончания действия бафа осталось: {20 - (steps - oldSteps)} шагов");
                }
                if (steps - oldSteps == 20)
                {
                    playerStrong = 10;
                    Console.SetCursorPosition(mapSize + 14, 18);
                    Console.Write("                                                              ");
                }
            }
        }

        static void Win() //экран победы
        {
            if (enemiesCount - 10 == 10)
            {
                Console.Clear();
                Console.SetCursorPosition(44, 12);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Вы выиграли! Поздравляю!");
                Console.ResetColor();

                Console.SetCursorPosition(41, 13);
                Console.WriteLine($"Количество пройденных шагов: {steps} ");

                Console.SetCursorPosition(41, 15);
                Console.Write($"Q - вернуться на стартовый экран");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q: //игрок решил вернуться на старт игры
                        StartGame();
                        break;
                    default:
                        Win();
                        break;
                }
            }
        }

        static void Death() //экран поражения
        {
            Console.Clear();
            Console.SetCursorPosition(38, 12);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Вы програли. Не грусти, начни заново!");
            Console.ResetColor();

            Console.SetCursorPosition(41, 13);
            Console.WriteLine($"Количество пройденных шагов: {steps} ");

            Console.SetCursorPosition(40, 15);
            Console.Write($"Q - вернуться на стартовый экран");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q: //игрок решил вернуться на старт игры
                    StartGame();
                    break;
                default:
                    Death();
                    break;
            }
        }

        static void StatisticsGame() //статистика игры
        {
            if (playerHealth <= 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(mapSize + 14, 10);
                Console.WriteLine($"Здоровье игрока: {playerHealth} ");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(mapSize + 14, 10);
                Console.WriteLine($"Здоровье игрока: {playerHealth} ");
            }

            Console.SetCursorPosition(mapSize + 14, 11);
            Console.WriteLine("Урон игрока: " + playerStrong);
            Console.SetCursorPosition(mapSize + 14, 14);
            Console.WriteLine($"Количество пройденных шагов: {steps} ");
            Console.SetCursorPosition(mapSize + 14, 15);
            Console.WriteLine($"Количество убитых врагов: {enemiesCount - 10} ");
        }

        static void Exit() //при нажатии Esc выводится экран "выхода"
        {
            Console.Clear();
            Console.SetCursorPosition(46, 12);
            Console.Write("EEsc - продолжить игру");
            Console.SetCursorPosition(46, 13);
            Console.Write("Y - сохранить игру");
            Console.SetCursorPosition(46, 14);
            Console.Write("Q - вернуться на стартовый экран");

            Console.CursorVisible = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape: //игрок продолжает игру
                    UpdateMap(); //выводится карта
                    break;
                case ConsoleKey.Y: //игрок сохраняет игру
                    Console.Clear();
                    SaveGame();
                    break;
                case ConsoleKey.Q: //игрок решил вернуться на старт игры
                    StartGame();
                    break;
                default:
                    Exit();
                    break;
            }
        }

        static void SaveGame() //сохранение игры
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("save.txt"))
                {
                    // Сохранение данных в файл
                    writer.WriteLine($"{playerX},{playerY},{playerHealth},{playerStrong}");
                    writer.WriteLine($"{enemiesCount},{steps},{oldSteps}");

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            writer.Write(map[i, j]);
                        }
                        writer.WriteLine();
                    }
                }
                Console.SetCursorPosition(42, 14);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Игра сохранена! Возвращайся!");
                Console.ResetColor();
                Console.ReadKey();
                StartGame();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(mapSize + 50, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при сохранении игры: {ex.Message}");
                Console.ResetColor();
                StartGame();
            }
        }

        static void LoadGame() //загрузка сохраненной игры
        {
            try
            {
                using (StreamReader reader = new StreamReader("save.txt"))
                {
                    // Инициализация карты перед загрузкой
                    map = new char[mapSize, mapSize];

                    // Загрузка данных из файла
                    string[] playerData = reader.ReadLine().Split(',');
                    playerX = int.Parse(playerData[0]);
                    playerY = int.Parse(playerData[1]);
                    playerHealth = int.Parse(playerData[2]);
                    playerStrong = int.Parse(playerData[3]);

                    //запись в массив игрока
                    map[playerX, playerY] = 'P';

                    string[] gameData = reader.ReadLine().Split(',');
                    enemiesCount = int.Parse(gameData[0]);
                    steps = int.Parse(gameData[1]);
                    oldSteps = int.Parse(gameData[2]);

                    for (int i = 0; i < mapSize; i++)
                    {
                        string line = reader.ReadLine();
                        for (int j = 0; j < mapSize; j++)
                        {
                            map[i, j] = line[j];
                        }
                    }
                }
                Console.SetCursorPosition(mapSize + 27, 14);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Игра загружена!");
                Console.ResetColor();
                Console.ReadKey();
                UpdateMap();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(mapSize + 2, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при загрузке игры: {ex.Message}");
                Console.ResetColor();
                LoadGame();
            }
        }

        static void UpdateMap() //полное обновление карты на консоли
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i, j])  //объявление цветов объектов
                    {
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                }
                Console.WriteLine(map[i, 0]);
            }
        }
    }
}