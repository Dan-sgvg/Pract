using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM_Task_Number_01
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter amount of gold:");

            int amount_of_gold; // = System.Convert.ToInt32(System.Console.ReadLine());

            bool isValidInt = int.TryParse(Console.ReadLine(), out amount_of_gold);


            int crystal_cost = 20;
            System.Console.WriteLine($"Crystal cost = {crystal_cost}");

            System.Console.WriteLine("How many crystals you want to buy?");
            int amount_of_crystals = System.Convert.ToInt32(System.Console.ReadLine());

            amount_of_gold = amount_of_gold - amount_of_crystals * crystal_cost;

            if (amount_of_gold <= 0)
                System.Console.WriteLine("You need more gold.");
            else
                System.Console.WriteLine($"You have {amount_of_gold} gold\nand {amount_of_crystals} crystals.");

            System.Console.ReadLine();
        }
    }
}
