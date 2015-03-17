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
                    bool added = false;
                    for (int i = 0; i < notes.Keys.Count; i++)
                    {                        
                        tryCash += notes.Keys[i];
                        if (tryCash > amount || notes[notes.Keys[i]]<0)
                        {
                            tryCash -= notes.Keys[i];                            
                        }
                        else
                        {
                            added = true;
                            try { givenNotes.Add(notes.Keys[i], 0); }
                            catch { givenNotes[notes.Keys[i]]++; }
                        }
                    }
                    if (added == false)
                    {
                        tryCash -= givenNotes[notes.Keys[notes.Keys.Count/2]];
                        if (givenNotes[notes.Keys[notes.Keys.Count / 2]] > 0) givenNotes[notes.Keys[notes.Keys.Count / 2]]--;
                        else givenNotes.Remove(notes.Keys.Count / 2);
                    }
                }
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
