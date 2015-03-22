using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class ATM
    {
        public SortedList<int, int> notes = new SortedList<int, int>();
        SortedList<int, int> givenNotes = new SortedList<int, int>();
        public long totalCash = 0;        
        public long Search(ref long tryCash,long requiredAmount)
        {
            for (int i = notes.Keys.Count-1; i >=0 ; i--)
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
                        
                        Search(ref tryCash, requiredAmount);
                    }
                    if (tryCash == requiredAmount)
                    {
                        
                        return tryCash;
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
            return 0;
        }
        public MoneyOuter GiveCash(long amount)
        {
            MoneyOuter message = new MoneyOuter();
            if (totalCash >= amount)
            {
                long tryCash = 0;
                givenNotes = new SortedList<int, int>();

                if (Search(ref tryCash, amount) != 0)
                {
                    for (int i = 0; i < givenNotes.Keys.Count; i++)
                    {
                        notes[givenNotes.Keys[i]] -= givenNotes[givenNotes.Keys[i]] + 1;
                    }
                    totalCash -= amount;
                    message.amount = amount;
                    return message;
                }
                else
                {
                    message.errorType = "ATM doesn`t have suitable notes.";
                    return message;
                }
            }
            message.errorType = "ATM doesn`t have enough money.";
            return message; 
        }        
    }    
}
