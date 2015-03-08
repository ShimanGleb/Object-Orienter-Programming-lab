using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM Atm = new ATM();
            while (true)
            {
                Console.WriteLine("Enter amount of money.");
                int TokenCash = Convert.ToInt32(Console.ReadLine());
                Atm.totalCash -= TokenCash;
                Console.WriteLine("The cash in amount of " + TokenCash + "$ was taken from your account.");
            }
        }
    }
}
