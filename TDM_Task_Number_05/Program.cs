using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_05
{
    class Program
    {
        static void Main(string[] args)
        {
                Random rnd = new Random();
            string[,] maze = { { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"}, 
                               { "#", ".", ".", ".", "#", ".", ".", ".", "#", ".", "#", ".", ".", ".", "#", ".", "#"},
                               { "#", "#", "#", ".", "#", ".", "#", "#", "#", ".", "#", "#", ".", "#", "#", ".", "#"},
                               { "#", ".", ".", ".", "#", ".", ".", ".", ".", ".", "#", ".", ".", ".", "#", ".", "#"},
                               { "#", ".", "#", ".", "#", "#", ".", "#", "#", ".", "#", ".", "#", ".", "#", ".", "#"},
                               { "#", ".", ".", "#", ".", ".", ".", "#", ".", "#", "#", ".", "#", ".", "#", ".", "#"},
                               { "#", "#", ".", "#", ".", "#", "#", "#", ".", ".", "#", ".", "#", ".", ".", ".", "#"},
                               { "#", ".", ".", "#", ".", ".", ".", ".", "#", ".", "#", ".", ".", "#", ".", ".", "#"},
                               { "#", ".", "#", "#", ".", "#", "#", ".", ".", ".", ".", "#", "#", "#", "#", ".", "#"},
                               { "#", ".", "#", ".", ".", ".", "#", "#", "#", ".", "#", "#", ".", ".", ".", ".", "#"},
                               { "#", ".", ".", ".", "#", ".", ".", ".", "#", ".", ".", ".", ".", "#", ".", ".", "#"},
                               { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"} };
            int x = maze.GetLength(0);
            int y = maze.GetLength(1);
            int exit = rnd.Next(1, x - 1);
            while (exit % 2 == 0)
            {
                exit = rnd.Next(1, x - 1);
            }

            int start = exit + 4;
            if (start >= x)
                start = 1;

            char user_movement;
            int exit_flag = 0;
            System.Console.WriteLine("Цель игры: выити из лабиринта," +
                "\n знаком # обозначеные стены," +
                "\n знаком P обозначено текущее местоположение игрока," +
                "\n знаком 0 обозначен выход.");
            System.Console.WriteLine("Движение осуществляется буквами w,a,s,d." +
                "\n Нажмите на любую кнопку чтобы начать движение.");
            System.Console.ReadLine();

            maze[0, exit] = "0";
            maze[1, start] = "P";
            int[] current_location = new int[2] { 1, start };

            while (true && exit_flag == 0)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write($"{maze[i, j]} ");
                    }
                    Console.Write("\n");
                }
                user_movement = Console.ReadKey().KeyChar;

                switch (user_movement)
                {
                    case 'ц':
                    case 'Ц':
                    case 'W':
                    case 'w':
                        {
                            
                            if (maze[current_location[0] - 1, current_location[1]] != "#")
                            {
                                maze[current_location[0], current_location[1]] = ".";
                                current_location[0] -= 1;
                                if (maze[current_location[0], current_location[1]] == "0")
                                    exit_flag += 1;
                                maze[current_location[0], current_location[1]] = "P";
                            }

                            break;
                        }
                    case 'Ф':
                    case 'ф':
                    case 'A':
                    case 'a':
                        {
                            if (maze[current_location[0], current_location[1] - 1] != "#")
                            {
                                maze[current_location[0], current_location[1]] = ".";
                                current_location[1] -= 1;
                                maze[current_location[0], current_location[1]] = "P";
                            }
                            break;
                        }
                    case 'S':
                    case 'ы':
                    case 'Ы':
                    case 's':
                        {
                            if (maze[current_location[0] + 1, current_location[1]] != "#")
                            {
                                maze[current_location[0], current_location[1]] = ".";
                                current_location[0] += 1;
                                maze[current_location[0], current_location[1]] = "P";
                            }
                            break;
                        }
                    case 'D':
                    case 'в':
                    case 'В':
                    case 'd':
                        {
                            if (maze[current_location[0], current_location[1] + 1] != "#")
                            {
                                maze[current_location[0], current_location[1]] = ".";
                                current_location[1] += 1;
                                maze[current_location[0], current_location[1]] = "P";
                            }
                            break;
                        }
                }
                System.Console.Clear();
            }
            maze[current_location[0], current_location[1]] = ".";
            current_location[0] += 1;
            maze[current_location[0], current_location[1]] = "P";

            System.Console.WriteLine("Поздравляю вы вышли!!");
            System.Console.ReadLine();
        }
    }
}
