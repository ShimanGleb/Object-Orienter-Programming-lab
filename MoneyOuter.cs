using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class MoneyOuter
    {
        public long amount=0;
        public string errorType = "None";
        public void GiveMoney()
        {
            if (amount == 0) Console.WriteLine("Error:" + errorType);
            else
            {
                Console.WriteLine("The cash in amount of " + amount + "$ was taken from your account.");
            }
        }
    }
}
