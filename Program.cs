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
            const string fileName = "cash.txt";
            MoneyLoader loader = new MoneyLoader();
            loader.LoadNotes(Atm,fileName);
            while (true)
            {                
                Console.WriteLine("Enter amount of money.");
                int TokenCash = Convert.ToInt32(Console.ReadLine());
                MoneyOuter money = new MoneyOuter();
                money = Atm.GiveCash(TokenCash);
                money.GiveMoney();                
            }
        }
    }
}
