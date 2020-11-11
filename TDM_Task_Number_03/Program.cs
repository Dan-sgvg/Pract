using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            int num_of_try = 0; string password = "dr.mom";
            Console.WriteLine("Введите секретный пароль.");
            do
            {
                Console.WriteLine($"Осатлось {3 - num_of_try} попытки.");
                expression = Console.ReadLine();
                num_of_try += 1;
                if (expression == password)
                {
                    Console.WriteLine("Secret massage!!");
                    break;
                }
            } while (num_of_try != 3);
            if (num_of_try == 3)
                Console.WriteLine("Лимит привышен!!");

            Console.ReadLine();
        }
    }
}
