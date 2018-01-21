namespace Сапёр
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const int size = 9;
        private const int countMines = 6;
        private static List<Сoordinates> mines = new List<Сoordinates>();
        private static int[,] mainArray = new int[size, size];
        private static string[,] gameArray = new string[size, size];

        static void Main(string[] args)
        {
            var rnd = new Random();
            while (mines.Count < countMines)
            {
                var coordinates = new Сoordinates();
                coordinates.x = rnd.Next(0, 9);
                coordinates.y = rnd.Next(0, 9);
                if (mines.Contains(coordinates) == false)
                {
                    mines.Add(coordinates);
                    mainArray[coordinates.x, coordinates.y] = -1;
                };
            };

            CreateGame();

            bool win = false;
            while (win == false)
            {

                Console.Clear();
                PrintMatrix(gameArray);
                Console.WriteLine("Ваш ход - ");
                try
                {
                    int x_p = int.Parse(Console.ReadLine());
                    int y_p = int.Parse(Console.ReadLine());

                    if (mainArray[x_p, y_p] >= 0)
                    {
                        gameArray[x_p, y_p] = "" + mainArray[x_p, y_p];
                    }
                    else
                    {
                        win = true;
                        Console.WriteLine("Вы проиграли");
                    }

                    if (mainArray[x_p, y_p] == 0)
                    {
                        OpenCell(x_p, y_p);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (CheckWin(gameArray) == countMines)
                {
                    win = true;
                    Console.Beep();
                    Console.Clear();
                    PrintMatrix(gameArray);
                    Console.WriteLine("Вы выиграли!");
                };
            }
        }

        /// <summary>
        /// Создание интерфейса и массива ответов
        /// </summary>
        private static void CreateGame()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i + 1 != size && j + 1 != size && mainArray[i + 1, j + 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (i + 1 != size && j - 1 != -1 && mainArray[i + 1, j - 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (i - 1 != -1 && j + 1 != size && mainArray[i - 1, j + 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (i - 1 != -1 && j - 1 != -1 && mainArray[i - 1, j - 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (i + 1 != size && mainArray[i + 1, j] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (i - 1 != -1 && mainArray[i - 1, j] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (j + 1 != size && mainArray[i, j + 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }
                    if (j - 1 != -1 && mainArray[i, j - 1] == -1)
                    {
                        if (mainArray[i, j] != -1)
                            mainArray[i, j]++;
                    }

                    gameArray[i, j] = "*";
                }
            }
        }

        /// <summary>
        /// Определить Победу
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int CheckWin(string[,] array)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (array[i, j] == "*")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Рекурсивное открытие ячеек
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void OpenCell(int x, int y)
        {
            gameArray[x, y] = mainArray[x, y].ToString();
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                if (mainArray[x - 1, y - 1] == 0 && gameArray[x - 1, y - 1] == "*")
                {
                    OpenCell(x - 1, y - 1);
                }
                else
                {
                    gameArray[x - 1, y - 1] = mainArray[x - 1, y - 1].ToString();
                }
            }
            if (x - 1 >= 0)
            {
                if (mainArray[x - 1, y] == 0 && gameArray[x - 1, y] == "*")
                {
                    OpenCell(x - 1, y);
                }
                else
                {
                    gameArray[x - 1, y] = mainArray[x - 1, y].ToString();
                }
            }
            if (x - 1 >= 0 && y + 1 < size)
            {
                if (mainArray[x - 1, y + 1] == 0 && gameArray[x - 1, y + 1] == "*")
                {
                    OpenCell(x - 1, y + 1);
                }
                else
                {
                    gameArray[x - 1, y + 1] = mainArray[x - 1, y + 1].ToString();
                }
            }
            if (x + 1 < size && y - 1 >= 0)
            {
                if (mainArray[x + 1, y - 1] == 0 && gameArray[x + 1, y - 1] == "*")
                {
                    OpenCell(x + 1, y - 1);
                }
                else
                {
                    gameArray[x + 1, y - 1] = mainArray[x + 1, y - 1].ToString();
                }
            }
            if (x + 1 < size)
            {
                if (mainArray[x + 1, y] == 0 && gameArray[x + 1, y] == "*")
                {
                    OpenCell(x + 1, y);
                }
                else
                {
                    gameArray[x + 1, y] = mainArray[x + 1, y].ToString();
                }
            }
            if (x + 1 < size && y + 1 < size)
            {
                if (mainArray[x + 1, y + 1] == 0 && gameArray[x + 1, y + 1] == "*")
                {
                    OpenCell(x + 1, y + 1);
                }
                else
                {
                    gameArray[x + 1, y + 1] = mainArray[x + 1, y + 1].ToString();
                }
            }
            if (y - 1 >= 0)
            {
                if (mainArray[x, y - 1] == 0 && gameArray[x, y - 1] == "*")
                {
                    OpenCell(x, y - 1);
                }
                else
                {
                    gameArray[x, y - 1] = mainArray[x, y - 1].ToString();
                }
            }
            if (y + 1 < size)
            {
                if (mainArray[x, y + 1] == 0 && gameArray[x, y + 1] == "*")
                {
                    OpenCell(x, y + 1);
                }
                else
                {
                    gameArray[x, y + 1] = mainArray[x, y + 1].ToString();
                }
            }
        }

        /// <summary>
        /// Вывод на экран
        /// </summary>
        /// <param name="array"></param>
        private static void PrintMatrix(string[,] array)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write('|');
                    Console.Write("_{0}_", array[i, j]);

                }
                Console.WriteLine("|" + i);
            }

            for (int i = 0; i < 9; i++)
                Console.Write("{0,4}", i);

            Console.WriteLine();
        }
    }
}