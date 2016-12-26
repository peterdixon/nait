using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_Peter_Dixon_Class_Library
{
    
    public class Utilities
    {
        public static int GetInt(string message)
        {
            int number = 0;
            bool error;

            string wrongTypeError = "\nThat is not an integer.\n";
            do
            {
                error = false;
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.Write(wrongTypeError);
                }
            } while (error == true);
            return number;
        }

        public static int GetInt(string message, int min, int max)
        {

            int number = 0;
            bool error;
            string outOfRangeError = "\nInteger is out of range\n";
            string wrongTypeError = "\nThat is not an integer.\n";
            do
            {
                error = false;
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.Write(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.Write(outOfRangeError);
                    }
                    if (number > max)
                    {
                        error = true;
                        Console.Write(outOfRangeError);
                    }
                }

            } while (error == true);
            return number;

        }

        public static double GetDouble(string message)
        {

            double number = 0;

            bool error;
           
            string wrongTypeError = "\nThat is not a double.\n";
            do
            {
                error = false;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.Write(wrongTypeError);
                }
            } while (error == true);
            return number;
        }

        public static double GetDouble(string message, double min, double max)
        {
            double number = 0;

            bool error;
            string outOfRangeError = "\nDouble is out of range\n";
            string wrongTypeError = "\nThat is not a double.\n";
            do
            {
                error = false;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.Write(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.Write(outOfRangeError);
                    }
                    if (number > max)
                    {
                        error = true;
                        Console.Write(outOfRangeError);
                    }
                }

            } while (error == true);

            //Calculations

            return number;
        }

        public static ConsoleKeyInfo Pause(string message)
        {
            Console.Write(message);
            return Console.ReadKey();
        }
    }
}
