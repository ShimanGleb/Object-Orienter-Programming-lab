using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class MoneyLoader
    {
        public void LoadNotes(ATM atm, string fileName)
        {          
            try
            {
                string[] strings = System.IO.File.ReadAllLines(fileName);
                foreach (string note in strings)
                {
                    string[] str = note.Split(' ');
                    atm.totalCash += Convert.ToInt32(str[0]) * Convert.ToInt32(str[1]);
                    atm.notes.Add(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
                }
            }
            catch 
            {
                Environment.Exit(0);
            }
        }
    }
}
