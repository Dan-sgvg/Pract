using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_07
{
    class Program
    {
        private static void Shuffle<T>(IList<T> arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var rndInd = rnd.Next(0, arr.Count());
                var rndInd2 = rnd.Next(0, arr.Count());
                var temp = arr[rndInd];
                arr[rndInd] = arr[rndInd2];
                arr[rndInd2] = temp;
            }
        }

        static void Main(string[] args)
        {
            //Random rnd = new Random();

            Console.WriteLine("Введите количество элементов массива:");
            bool isValidInt = int.TryParse(Console.ReadLine(), out int amount_of_numbers);
            List<int> numbers = new List<int>();

            for (int i = 0; i <= amount_of_numbers; i++)
            {
                numbers.Add(i);
            }
            //Console.WriteLine();    
            Console.WriteLine(string.Join(" ", numbers));
            Shuffle(numbers);

            //Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Join(" ", numbers));
            //Console.ResetColor();
            Console.ReadKey();
        }
    }
}
