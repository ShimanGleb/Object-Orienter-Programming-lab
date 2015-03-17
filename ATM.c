uusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class ATM
    {
        SortedList<int, int> notes = new SortedList<int, int>();
        SortedList<int, int> givenNotes = new SortedList<int, int>();
        public long totalCash = 0;
        public long Search(ref long tryCash,long requiredAmount)
        {
            for (int i = 0; i < notes.Keys.Count; i++)
            {
                tryCash += notes.Keys[i];
                if (tryCash > requiredAmount) tryCash -= notes.Keys[i];
                if (tryCash == requiredAmount)
                {
                    try { givenNotes[notes.Keys[i]]++; }
                    catch { givenNotes.Add(notes.Keys[i], 0); }
                    return tryCash;
                }
                else
                {
                    Search(ref tryCash, requiredAmount);
                }
            }
            return 0;
        }
        public long GiveCash(long amount)
        {
            if (totalCash >= amount)
            {
                long tryCash = 0;
                givenNotes = new SortedList<int, int>();
                Search(ref tryCash, amount);
                for (int i = 0; i < givenNotes.Keys.Count; i++)
                {
                    notes[notes.Keys[i]] -= givenNotes[notes.Keys[i]];
                }
                totalCash -= amount;
            }
            else return 0;
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
