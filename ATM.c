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
        public long GiveCash(long amount)
        {
            if (totalCash >= amount)
            {
                long tryCash = 0;
                SortedList<int, int> givenNotes = new SortedList<int, int>();
                while (tryCash != amount)
                {
                    for (int i = 0; i < notes.Keys.Count; i++)
                    {
                        tryCash += notes.Keys[i];
                        if (tryCash > amount)
                        {
                            tryCash -= notes.Keys[i];
                        }
                        else
                        {
                            try { givenNotes.Add(notes.Keys[i], 0); }
                            catch { givenNotes[notes.Keys[i]]++; }
                        }
                    }
                }

                totalCash -= amount;
            }
            else return -1;
            return amount;            
        }
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
