using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    public class CUtilities
    {
        //GetInt
        public static int GetInt(string message)
        {
            int number = 0;
            bool error;

            string wrongTypeError = "An invalid number was entered. Please try again.\n";
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
        //GetInt with min
        public static int GetInt(string message, int min)
        {

            int number = 0;
            bool error;
            string belowRangeError = "The value entered is below the minimum accepted.";
            string wrongTypeError = "An invalid number was entered. Please try again.";
            do
            {
                error = false;
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.WriteLine(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.WriteLine(belowRangeError);
                    }

                }

            } while (error == true);
            return number;

        }
        //GetInt with min and max
        public static int GetInt(string message, int min, int max)
        {

            int number = 0;
            bool error;
            string outOfRangeError = "The value entered is outside the range accepted.";
            string wrongTypeError = "An invalid number was entered. Please try again.";
            do
            {
                error = false;
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.WriteLine(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.WriteLine(outOfRangeError);
                    }
                    if (number > max)
                    {
                        error = true;
                        Console.WriteLine(outOfRangeError);
                    }
                }

            } while (error == true);
            return number;

        }

       
        //GetDouble
        public static double GetDouble(string message)
        {

            double number = 0;

            bool error;

            string wrongTypeError = "An invalid number was entered. Please try again.";
            do
            {
                error = false;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.WriteLine(wrongTypeError);
                }
            } while (error == true);
            return number;
        }

        //GetDouble with min
        public static double GetDouble(string message, double min)
        {
            double number = 0;

            bool error;
            string belowRangeError = "The value entered is below the minimum accepted.";
            string wrongTypeError = "An invalid number was entered. Please try again.";
            do
            {
                error = false;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.WriteLine(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.WriteLine(belowRangeError);
                    }
                }

            } while (error == true);

          

            return number;
        }
        //GetDouble with min and max
        public static double GetDouble(string message, double min, double max)
        {
            double number = 0;

            bool error;
            string outOfRangeError = "The value entered is outside the range accepted.";
            string wrongTypeError = "An invalid number was entered. Please try again.";
            do
            {
                error = false;
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number) == false)
                {
                    error = true;
                    Console.WriteLine(wrongTypeError);
                }
                else
                {
                    if (number < min)
                    {
                        error = true;
                        Console.WriteLine(outOfRangeError);
                    }
                    if (number > max)
                    {
                        error = true;
                        Console.WriteLine(outOfRangeError);
                    }
                }

            } while (error == true);

            //Calculations

            return number;
        }

        public static ConsoleKeyInfo Pause(string message)
        {
            ConsoleKeyInfo cki;
            Console.Write(message);

            cki = Console.ReadKey();
            Console.Write("\n");
            return cki;
        }

        public static double GetAverageOfArray(Array myArray)
        {
            double average;
            double sum = 0;
            double size = 0;

            foreach (int item in myArray)
            {
                sum += item;
                size += 1;
            }

            average = sum / size;

            return average;
        }

      
    }
}
