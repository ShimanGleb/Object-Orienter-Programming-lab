using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace FOOPLab1
{
    class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));
        [STAThread]
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Starting process.");
            ATM Atm = new ATM();
            const string fileName = "cash.txt";
            MoneyLoader loader = new MoneyLoader();
            Atm.ProceedCassetes(loader.LoadNotes(Atm, fileName));

            TextLoader textLoader = new TextLoader();
            SortedList<string, string> languages = new SortedList<string, string>();
            languages = textLoader.GiveLanguages();
            Console.WriteLine("Choose language:");

            for (int i = 0; i < languages.Keys.Count; i++)
            {
                Console.WriteLine(languages.Keys[i] + " - " + (i+1));
            }

            int languageNumber = Convert.ToInt32(Console.ReadLine());
            textLoader.LoadText(languages[languages.Keys[languageNumber - 1]]);
            log.Info("Process start: success.");
            while (true)
            {
                Console.WriteLine(textLoader.ReturnMessage("moneyAskMessage"));                
                var askedSum = Console.ReadLine();
                log.Info("Entered sum: " + askedSum);
                int tokenCash=0;
                try
                {
                    tokenCash = Convert.ToInt32(askedSum);
                }
                catch
                {
                    log.Info("Error: invalid sum value.");
                }
                StateChecker checker = new StateChecker();                           
                Money money = Atm.GiveCash(tokenCash);
                if (money.totalSum == 0)
                {
                    string state = checker.CheckState(tokenCash, Atm.totalCash, Atm.notes);
                    string errorMessage = textLoader.ReturnMessage("errorMessage") + textLoader.ReturnMessage(state);
                    Console.WriteLine(errorMessage);
                    log.Info(errorMessage);
                }
                else
                {
                    log.Info("Money give: success.");
                    MoneyOuter moneyOuter = new MoneyOuter();
                    Console.WriteLine(moneyOuter.GiveMessage(money, textLoader));
                }                
                Console.WriteLine("-----------------------------");
            }
        }
    }
}