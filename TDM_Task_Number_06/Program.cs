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
                Console.Clear();
                Console.WriteLine("Функция заполнения массивов:" +
                    "\n1- Добавить досье.  " +
                    "\n2- Вывести все досье." +
                    "\n3- Удалить досье. " +
                    "\n4- Поиск по фамилии. " +
                    "\nИная другая цифра или буква завершит программу.\n");
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
                            else
                                Console.WriteLine("Нет ни одного досье.");
                            break;
                        }
                    case 3:
                        {

                            if (amount_of_files == 1)
                            {
                                amount_of_files--;
                                Array.Resize<string>(ref full_name, amount_of_files);
                                Array.Resize<string>(ref post, amount_of_files);
                                Console.WriteLine("Досье удалено.");
                            }
                            else
                            if (amount_of_files>0)
                            {
                                Delete(full_name, post, amount_of_files);
                                amount_of_files--;
                                Array.Resize<string>(ref full_name, amount_of_files);
                                Array.Resize<string>(ref post, amount_of_files);
                                Console.WriteLine("Досье удалено.");
                            }
                            else
                                Console.WriteLine("Нет ни одного досье.");
                            chose = 0;
                            break;
                        }
                    case 4:
                        {
                            if (amount_of_files > 0)
                                Search(amount_of_files,full_name,post);
                            else
                                Console.WriteLine("Нет ни одного досье.");

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
            Console.WriteLine("Введите Фамилию:");
            full_name[amount_of_files - 1] = ": " + Console.ReadLine();
            Console.WriteLine("Введите Имя:");
            full_name[amount_of_files - 1] += " " + Console.ReadLine();
            Console.WriteLine("Введите Отчество:");
            full_name[amount_of_files - 1] += " " + Console.ReadLine();
            Console.WriteLine("Введите должность:");
            post[amount_of_files - 1] = Console.ReadLine();
            
        }

        static void Out(int i,int amount_of_files, string[] full_name, string[] post)
        {
            Console.WriteLine($"№{i + 1} ФИО{full_name[i]}  Должность: {post[i]}.");
        }

        static void Search(int amount_of_files, string[] full_name, string[] post)
        {
            string search_name;
            Console.WriteLine("Введите фамилию искомого человека:");
            search_name = Console.ReadLine();
            for (int i = 0; i < amount_of_files; i++)
                if (full_name[i].Contains(": " + search_name ))
                    Console.WriteLine($"№{i + 1} ФИО{full_name[i]}  Должность: {post[i]}.");
        }

        static void Delete(string[] full_name, string[] post, int amount_of_files)
        {
            Console.WriteLine("Введите номер досье для удаления:");
            bool isValidInt = int.TryParse(Console.ReadLine(), out int chose);

            if (isValidInt == true && chose - 1 < amount_of_files && chose - 1 >= 0 && amount_of_files > 1)
            {
                for (int i = chose - 1; i < amount_of_files - 1; i++)
                {
                    full_name[i] = full_name[i + 1];
                    post[i] = post[i + 1];
                };
                
            }
        }
    }
}
