using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сапёр
{
    class Program
    {
        class koord
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            int[,] otv = new int[9, 9];
            Random x = new Random();
            List<koord> r = new List<koord>();
            int it = 0;
            bool flag;
            while (it < 9)
            {
                flag = false;
                koord kor = new koord();
                kor.x = x.Next(0, 9);
                kor.y = x.Next(0, 9);
                foreach (koord l in r)
                {
                    if (l.x == kor.x && l.y == kor.y)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    r.Add(kor);
                    otv[kor.x, kor.y] = -1;
                    it++;
                };
            };
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int tempi = i;
                    int tempj = j;
                    if (tempi + 1 != 9 && tempj + 1 != 9 && otv[tempi + 1, tempj + 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempi + 1 != 9 && tempj - 1 != -1 && otv[tempi + 1, tempj - 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempi - 1 != -1 && tempj + 1 != 9 && otv[tempi - 1, tempj + 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempi - 1 != -1 && tempj - 1 != -1 && otv[tempi - 1, tempj - 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempi + 1 != 9 && otv[tempi + 1, tempj] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempi - 1 != -1 && otv[tempi - 1, tempj] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempj + 1 != 9 && otv[tempi, tempj + 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                    tempi = i;
                    tempj = j;
                    if (tempj - 1 != -1 && otv[tempi, tempj - 1] == -1)
                    {
                        if (otv[tempi, tempj] != -1)
                            otv[tempi, tempj]++;
                    }
                }
            }

            string[,] interf = new string[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    interf[i, j] = "*";
                }
            }

            bool win = true;
            while (win == true)
            {
                Console.Clear();
                Console.WriteLine();
                printmatrchar(interf);
                Console.WriteLine("Ваш ход - ");
                try
                {
                    int x_p = Int32.Parse(Console.ReadLine());
                    int y_p = Int32.Parse(Console.ReadLine());

                    if (otv[x_p, y_p] >= 0)
                    {
                        interf[x_p, y_p] = "" + otv[x_p, y_p];
                    }
                    else {
                        win = false;
                        Console.WriteLine("Вы проиграли");
                    }

                    if (otv[x_p, y_p] == 0)
                    {
                        bool flagnulls = true;
                        while (flagnulls == true)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {

                                    if (i + 1 != 9 && j + 1 != 9 && interf[i + 1,j + 1] == "0")
                                    {
                                        interf[i , j] = "" + otv[i , j];
                                        continue;
                                        flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }
                                    if (i + 1 != 9 && j - 1 != -1 && interf[i + 1, j - 1] == "0")
                                    {
                                        interf[i, j] = "" + otv[i , j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }
                                    if (i - 1 != -1 && j + 1 != 9 && interf[i - 1, j + 1] == "0")
                                    {
                                        interf[i, j] = "" + otv[i, j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }
                                    if (i - 1 != -1 && j - 1 != -1 && interf[i - 1, j - 1] == "0")
                                    {
                                        interf[i , j] = "" + otv[i , j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }

                                    if (i + 1 != 9 && interf[i + 1, j] == "0")
                                    {
                                        interf[i , j ] = "" + otv[i , j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }

                                    if (j + 1 != 9 && interf[i , j+ 1] == "0")
                                    {
                                        interf[i, j] = "" + otv[i, j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }

                                    if (i - 1 != -1 && interf[i - 1, j] == "0")
                                    {
                                        interf[i, j] = "" + otv[i , j]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }

                                    if (j - 1 != -1 && interf[i , j- 1] == "0")
                                    {
                                        interf[i, j] = "" + otv[i, j ]; continue; flagnulls = true;
                                    }
                                    else {
                                        flagnulls = false;
                                    }
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (checkwin(interf) == 10)
                {
                    win = false;
                    Console.Beep();
                    Console.WriteLine("Вы выиграли!");
                };
            }
        }

        private static int checkwin(string[,] a)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (a[i, j] == "*")
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static void printmatrint(int[,] a)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("|_{0,2}_", a[i, j]);

                }
                Console.Write("|" + i);
                Console.WriteLine();
            }

            for (int i = 0; i < 9; i++)
                Console.Write("{0,5}", i);
            Console.WriteLine();
        }
        private static void printmatrchar(string[,] a)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write('|');
                    Console.Write("_{0}_", a[i, j]);

                }
                Console.Write("|" + i);
                Console.WriteLine();
            }

            for (int i = 0; i < 9; i++)
                Console.Write("{0,4}", i);
            Console.WriteLine();
        }
    }
}
