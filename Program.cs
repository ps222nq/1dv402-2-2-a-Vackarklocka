using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2A
{
    class Program
    {

        //Fields
        static string HorizontalLine = "================================================================================";
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║           Väckarklockan              ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine();

            //Test1
            AlarmClock aClock1 = new AlarmClock();
            ViewTestHeader(1, "Standardkonstruktorn");
            Console.WriteLine(aClock1.ToString());

            //Test2
            AlarmClock aClock2 = new AlarmClock(9,42);
            ViewTestHeader(2, "Konstruktor med 2 parameter");
            Console.WriteLine("{0}", aClock2.ToString());

            //Test3
            AlarmClock aClock3 = new AlarmClock(13, 24, 7, 35);
            ViewTestHeader(3, "Konstruktor med 4 parameter");
            Console.WriteLine(aClock3.ToString());

            //Test4
            ViewTestHeader(4, "\n Ställer befintligt AlarmClock objekt till 23:58 och låter den gå 13 minuter.");
            aClock3.Hour = 23;
            aClock3.Minute = 58;
            Run(aClock3,13);

            //Test5
            ViewTestHeader(5, "\nStäller befintlig AlarmClock till 6:12 med alarm 6:15 och låter tiden gå 6 minuter.");
            aClock3.Hour = 6;
            aClock3.Minute = 12;
            aClock3.AlarmHour = 6;
            aClock3.AlarmMinute = 15;
            Run(aClock3, 6);

            //Test6
            ViewTestHeader(6, "\nTest av egenskaperna så att undantag kastas när tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                aClock3.Hour = 45;
                aClock3.Minute = 122;
                aClock3.AlarmHour = -6;
                aClock3.AlarmMinute = 150;
            }
            catch (ArgumentOutOfRangeException)
            {
                ViewErrorMessage("Ett eller flera värden ligger inte inom det tillåtna intervallet. 0-59 för minuter, 0-23 för timmar.");
                
            }

            
            //Test 7
            ViewTestHeader(7, "\nTest av konstruktor så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                AlarmClock aClock4 = new AlarmClock(25, 88, -3, 1000);
            }
            catch(ArgumentOutOfRangeException)
            {
                ViewErrorMessage("Ett eller flera värden ligger inte inom det tillåtna intervallet. 0-59 för minuter, 0-23 för timmar.");
            }


        }

        /// <summary>
        /// Runs the clock a specifiied number of minutes, displays alarm message if applicable
        /// </summary>
        /// <param name="ac">an instance of AlarmClock</param>
        /// <param name="minutes">the amount of minutes to increase the time with</param>
        private static void Run(AlarmClock ac, int minutes)
        {
            for (int i = 0; i < minutes; i++) 
            {
                if (ac.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} is alarm time! Wake up! ♫", ac.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(String.Format("{0}", ac.ToString()));
                }
            }
        }

        /// <summary>
        /// Displays apologetic error text followed by user specified message, formatted red/white.
        /// </summary>
        /// <param name="message">Specific error message specified by the user</param>
        private static  void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hoppsan! Ett fel inträffade: " +  message);
            Console.ResetColor();
        }

        /// <summary>
        /// Formats a header for printing the results of tests to the console.
        /// </summary>
        /// <param name="testNumber">Which number in the test sequence the current test is</param>
        /// <param name="header">What the header text describing the test should be</param>
        private static void ViewTestHeader(int testNumber, string header)
        {            
            Console.WriteLine("\n{0}\n         Test " + testNumber + ": {1}. \n{2}", HorizontalLine, header, HorizontalLine);            
        }
    }
}