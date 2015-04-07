using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOOPLab1
{
    class TextLoader
    {        
        string filename = "en.txt";
        public string currencyName;
        public string moneyAskMessage;
        public string errorMessage;
        public string invalidAmountMessage;
        public string notEnoughMessage;
        public string notSuitableMessage;
        public string recievingMessage;
        public string noteValueMessage;
        public void LoadText()
        {
            string[] strings = System.IO.File.ReadAllLines(filename);
            currencyName=strings[0];
            moneyAskMessage = strings[1];
            errorMessage = strings[2];
            invalidAmountMessage = strings[3];
            notEnoughMessage = strings[4];
            notSuitableMessage = strings[5];
            recievingMessage = strings[6];
            noteValueMessage = strings[7];            
        }
        public string ReturnMessage(string messageName)
        {
            string message="";
            if (messageName == "currencyName") return currencyName;
            if (messageName == "moneyAskMessage") return moneyAskMessage;
            if (messageName == "errorMessage") return errorMessage;
            if (messageName == "invalidAmountMessage") return invalidAmountMessage;
            if (messageName == "notEnoughMessage") return notEnoughMessage;
            if (messageName == "notSuitableMessage") return notSuitableMessage;
            if (messageName == "recievingMessage") return recievingMessage;
            if (messageName == "noteValueMessage") return noteValueMessage;
            return message;
        }
    }
}
