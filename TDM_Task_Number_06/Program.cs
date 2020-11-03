using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_06
{
    class Program
    {

        static void Main(string[] args)
        {
            int chose;
            int amount_of_files;

            string[] post = new string[1] {""};
            string[] full_name = new string[1] {""};
            chose = 0;
            amount_of_files = 0;

            Console.WriteLine("Функция заполнения массивов:" +
                "\n1- Добавить досье.  " +
                "\n2- Вывести все досье." +
                "\n3- Удалить досье. " +
                "\n4- Поиск по фамилии. " +
                "\nИная другая цифра или буква завершит программу.\n");

            while (chose != 5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите цифру(1-4):");
                Console.ResetColor();
                bool isValidInt = int.TryParse(Console.ReadLine(), out chose);
                Console.WriteLine("");

                switch (chose)
                {
                    case 1:
                        {
                            amount_of_files ++;
                            Array.Resize<string>(ref full_name, amount_of_files);
                            Array.Resize<string>(ref post, amount_of_files);
                            Enter(amount_of_files,full_name,post);
                            break;
                        }
                    case 2:
                        {
                            if (amount_of_files > 0)
                                for (int i = 0; i < amount_of_files; i++)
                                    Out(i, amount_of_files, full_name, post);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите номер досье для удаления:");
                            isValidInt = int.TryParse(Console.ReadLine(), out chose);

                            if (isValidInt == true && chose-1 < amount_of_files && chose-1 >= 0 && amount_of_files > 1)
                            {
                                for (int i = chose-1; i < amount_of_files-1; i++)
                                {
                                        full_name[i] = full_name[i + 1];
                                        post[i] = post[i + 1];
                                };

                                amount_of_files--;
                                Array.Resize<string>(ref full_name, amount_of_files);
                                Array.Resize<string>(ref post, amount_of_files);
                            }
                            else
                                if (isValidInt == true && chose - 1 == 0 && amount_of_files == 1)
                                {
                                    amount_of_files--;
                                    Array.Resize<string>(ref full_name, amount_of_files);
                                    Array.Resize<string>(ref post, amount_of_files);
                                }
                            chose = 0;
                            break;
                        }
                    case 4:
                        {
                            if (amount_of_files > 0)
                            {
                                Search(amount_of_files,full_name,post);
                            }

                            break;
                        }  
                    default:
                        {
                            chose = 5;
                            break;
                        }
                }

                
            }
            Console.ReadLine();
        }
        static void Enter(int amount_of_files, string[] full_name, string[] post)
        {
            Console.WriteLine("Введите имя:");
            full_name[amount_of_files - 1] = Console.ReadLine();
         
            Console.WriteLine("Введите должность:");
            post[amount_of_files - 1] = Console.ReadLine();
            
        }

        static void Out(int i,int amount_of_files, string[] full_name, string[] post)
        {
            Console.WriteLine($"{i + 1}: человек по имени {full_name[i]} с должностью {post[i]}.");
        }

        static void Search(int amount_of_files, string[] full_name, string[] post)
        {
            string search_name;
            Console.WriteLine("Введите искомое имя:");
            search_name = Console.ReadLine();
            for (int i = 0; i < amount_of_files; i++)
                if (full_name[i] == search_name)
                    Console.WriteLine($"{i + 1}: человек по имени {full_name[i]} с должностью {post[i]}.");
        }
    }
}
