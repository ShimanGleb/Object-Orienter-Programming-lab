using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class MoneyLoader
    {
        public List<Cassete> LoadNotes(ATM atm, string fileName)
        {
            List<Cassete> cassetes = new List<Cassete>();
            try
            {
                string[] strings = System.IO.File.ReadAllLines(fileName);                
                foreach (string note in strings)
                {
                    string[] str = note.Split(' ');
                    Cassete cassete = new Cassete();
                    cassete.noteValue = Convert.ToInt32(str[0]);
                    cassete.noteCount = Convert.ToInt32(str[1]);
                    cassetes.Add(cassete);
                    
                }                
            }
            catch 
            {
                Environment.Exit(0);
            }
            return cassetes;
        }
    }
}
