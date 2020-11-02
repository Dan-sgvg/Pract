using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_02
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Enter exit to end program.");
            string expression;
            do {
                expression = Console.ReadLine();
            } while (!expression.Equals("exit"));
        }
    }
}
