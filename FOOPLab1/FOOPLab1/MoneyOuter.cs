using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace FOOPLab1
{
    class MoneyOuter
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(MoneyOuter));        
        public string GiveMessage(Money money, TextLoader textLoader)
        {
            string message =textLoader.ReturnMessage("recievingMessage");
            string logData="";                
            for (int i = 0; i < money.notes.Keys.Count; i++)
            {
                message+=(money.notes[money.notes.Keys[i]] + 1) + textLoader.ReturnMessage("noteValueMessage") + money.notes.Keys[i] + textLoader.ReturnMessage("currencyName");
                logData += " " + (money.notes[money.notes.Keys[i]] + 1).ToString() + " " + money.notes.Keys[i].ToString() + ";";
            }
            log.Info(money.totalSum + " =>" + logData);
            return message;       
        }
    }
}