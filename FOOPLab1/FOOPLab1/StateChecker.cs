using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace FOOPLab1
{
    class StateChecker
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(StateChecker));
        SortedList<int, int> givenNotes = new SortedList<int, int>();
        string CheckNotes(ref long tryCash, long requiredAmount, SortedList<int, int> notes)
        {
            for (int i = notes.Keys.Count - 1; i >= 0; i--)
            {
                tryCash += notes.Keys[i];
                if (tryCash > requiredAmount)
                {
                    tryCash -= notes.Keys[i];
                }
                else
                {
                    try { givenNotes[notes.Keys[i]]++; }
                    catch { givenNotes.Add(notes.Keys[i], 0); }
                    if (tryCash < requiredAmount)
                    {

                        CheckNotes(ref tryCash, requiredAmount, notes);
                    }
                    if (tryCash == requiredAmount)
                    {
                        return "Valid";
                    }
                }
                if (i == 0)
                {
                    try
                    {
                        if (givenNotes[notes.Keys[i]] > 0)
                        {

                            givenNotes[notes.Keys[i]]--;

                        }
                        else givenNotes.Remove(notes.Keys[i]);
                    }
                    catch { }
                }
            }
            return "notSuitableMessage";
        }

        public string CheckState(int amount, long totalCash,SortedList<int, int> notes)
        {            
            if (amount <= 0)
            {
                return "invalidAmountMessage";
            }
            if (totalCash < amount)
            {
                return "notEnoughMessage";
            }
            long tryCash = 0;
            return CheckNotes(ref tryCash, amount, notes); ;
        }
    }
}
