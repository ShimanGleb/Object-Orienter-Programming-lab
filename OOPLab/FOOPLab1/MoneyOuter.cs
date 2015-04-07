using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class MoneyOuter
    {
        public SortedList<int, int> givenNotes = new SortedList<int, int>();
        public string errorType = "None";
        public void GiveMoney()
        {
            TextLoader textLoader = new TextLoader();
            textLoader.LoadText();
            if (errorType != "None") Console.WriteLine(textLoader.ReturnMessage("errorMessage") + textLoader.ReturnMessage(errorType));
            else
            {
                Console.WriteLine(textLoader.ReturnMessage("recievingMessage"));
                for (int i = 0; i < givenNotes.Keys.Count; i++)
                {
                    Console.WriteLine((givenNotes[givenNotes.Keys[i]]+1) + textLoader.ReturnMessage("noteValueMessage") + givenNotes.Keys[i] + textLoader.ReturnMessage("currencyName"));
                }
            }
            Console.WriteLine("-----------------------------");
        }
    }
}