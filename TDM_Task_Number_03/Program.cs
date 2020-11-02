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
            int num_of_try = 0;
            do
            {
                expression = Console.ReadLine();
                num_of_try += 1;
                if (expression.Equals("dr.mom"))
                {
                    Console.WriteLine("Secret massage!!");
                    break;
                }
            } while (num_of_try != 3);
            if (num_of_try == 3)
                Console.WriteLine("limit is exceeded!!");

            Console.ReadLine();
        }
    }
}
