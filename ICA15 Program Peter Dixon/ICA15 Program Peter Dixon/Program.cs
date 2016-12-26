using System;

using ICA15_Peter_Dixon_Class_Library;


namespace ICA15_Program_Peter_Dixon
{
    class Program
    {
        static void Main(string[] args)
        {
            string intMessage = "Enter an integer: ";
            string doubleMessage = "Enter a double: ";
            int intMin = 0;
            int intMax = 100;
            double doubleMin = 0;
            double doubleMax = 100.0;
            int intResult;
            double doubleResult;
            ConsoleKeyInfo cki;
            
            intResult = Utilities.GetInt(intMessage);
            Console.Write("you entered {0}", intResult);
            intResult = Utilities.GetInt(intMessage, intMin, intMax);
            Console.Write("you entered {0}", intResult);

            doubleResult = Utilities.GetDouble(doubleMessage, doubleMin, doubleMax);
            Console.Write("you entered {0}", doubleResult);
            doubleResult = Utilities.GetDouble(doubleMessage);
            Console.Write("you entered {0}", doubleResult);

            cki = Utilities.Pause("Enter a key");

            Console.WriteLine("You entered {0}", cki.Key);

            Console.ReadKey();

        }
    }
}
