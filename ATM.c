using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class ATM
    {
        SortedList<int, int> notes = new SortedList<int, int>();
        public long totalCash = 0;
        public ATM()
        {
            const string fileName = "cash.txt";
            try
            {
                string[] strings = System.IO.File.ReadAllLines(fileName);
                foreach (string note in strings)
                {
                    string[] str = note.Split(' ');
                    totalCash += Convert.ToInt32(str[0]) * Convert.ToInt32(str[1]);
                    notes.Add(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
                }
            }
            catch { }
        }
    }
}
