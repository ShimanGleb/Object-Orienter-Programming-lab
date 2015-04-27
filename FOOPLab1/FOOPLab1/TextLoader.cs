using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class TextLoader
    {        
        public string languageFile = "language-files.txt";
        Dictionary<string, string> messages = new Dictionary<string, string>();

        public SortedList<string, string> GiveLanguages()
        {
            SortedList<string, string> languages = new SortedList<string, string>();
            string[] strings = System.IO.File.ReadAllLines(languageFile);
            foreach (string language in strings)
            {
                languages.Add(language.Split(' ')[0], language.Split(' ')[1]);
            }
            return languages;
        }

        public void LoadText(string filename)
        {
            string[] strings = System.IO.File.ReadAllLines(filename);
            messages.Add("currencyName", strings[0]);
            messages.Add("moneyAskMessage", strings[1]);
            messages.Add("errorMessage", strings[2]);
            messages.Add("invalidAmountMessage", strings[3]);
            messages.Add("notEnoughMessage", strings[4]);
            messages.Add("notSuitableMessage", strings[5]);
            messages.Add("recievingMessage", strings[6]);
            messages.Add("noteValueMessage", strings[7]);          
        }

        public string ReturnMessage(string messageName)
        {
            return messages[messageName];
        }
    }
}
