using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using System.IO;

namespace Utilities
{

    public class CUtilities
    {
        #region GetInt
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
        #endregion
        #region GetDouble
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
        #endregion
        public static ConsoleKeyInfo Pause(string message)
        {
            ConsoleKeyInfo cki;
            Console.Write(message);

            cki = Console.ReadKey();
            Console.Write("\n");
            return cki;
        }

        //Array Methods


        public static int[] GetArray(string message)
        {
            Random generator = new Random();
            int size = GetInt(message);
            int[] myArray = new int[size];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = generator.Next(0, 101);
            }
            return myArray;
        }
        public static void DisplayArray(int[] myArray)
        {
            if (myArray.Length == 0)
            {
                throw new ArgumentNullException();

            }
            Array.Sort(myArray);

            Console.WriteLine("\nThe array has been sorted");

            Console.WriteLine("\nThe current contents of the array:");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write("{0}\t", myArray[i]);
            }
            Console.WriteLine();

        }
        public static double GetAverageOfArray(Array myArray)
        {
            if (myArray.Length == 0)
            {
                throw new ArgumentException();
            }
            double average;
            double sum = 0;
            double size = myArray.Length;
            foreach (int item in myArray)
            {
                sum += item;

            }
            average = sum / size;
            return average;
        }
        public static void DrawGradesHistogram(int[] grades)
        {
            if (grades.Length == 0)
            {
                throw new ArgumentException();
            }
            CDrawer gdi = new CDrawer();            //Initialize an instance of CDrawer
            gdi.ContinuousUpdate = false;
            int[] histogram = new int[11];        //This array counts the number of grades in each of the 11 ranges from 0-100.
            int[] Heights = new int[histogram.Length];    //This array holds the height of each histogram bar


            string[] legendMessages = new string[histogram.Length]; //Each element in this array is the range on the bottom of the histogram.
            int legendHeight = 20;                          //Height of the Histogram legend

            int maxHeight = gdi.m_ciHeight - legendHeight;    //Maximum height of the histogram bars.
            double entryHeight;                                 //Used to scale height of the histogram bar to the maximum.           
            int entryWidth = gdi.m_ciWidth / histogram.Length;  //Width of histogram bar

            //Create the Histogram Legend.
            for (int i = 0; i < legendMessages.Length - 1; i++)
            {

                legendMessages[i] = String.Format("{0} to {1}", i * 10, i * 10 + 9);
            }
            legendMessages[10] = "100";

            //Calculate frequency of each grade range.
            for (int i = 0; i < histogram.Length - 1; i++)
            {
                histogram[i] = CountOfValueRangeinIntegerArray(grades, i * 10, (i + 1) * 10);
            }
            histogram[10] = CountOfValueRangeinIntegerArray(grades, 100);

            for (int i = 0; i < Heights.Length; i++)
            {
                //Draw the histogram
                entryHeight = ((double)histogram[i] / histogram.Max()) * maxHeight;
                Heights[i] = (int)entryHeight;
                Console.Write("{0}\t", Heights[i]);
                gdi.AddRectangle(i * entryWidth, maxHeight - Heights[i], entryWidth, Heights[i], getColor(i));

                //Display the legend
                gdi.AddText(legendMessages[i], 10, i * entryWidth, maxHeight, entryWidth, legendHeight, Color.Teal);

                //Display the counts
                gdi.AddText(String.Format("{0}", histogram[i]), 10, i * entryWidth, maxHeight - (Heights[i] / 2), entryWidth, legendHeight);


            }


            gdi.Render();



        }
        public static int CountOfValueRangeinIntegerArray(int[] myArray, int value)
        {
            int count = 0;
            foreach (var item in myArray)
            {
                if (item == value)
                {
                    count += 1;
                }
            }

            return count;
        }
        public static int CountOfValueRangeinIntegerArray(int[] myArray, int inclusiveMin, int exclusiveMax)
        { // Inclusive lower bound and exclusive upper bound.
            int count = 0;
            foreach (var item in myArray)
            {
                if (item >= inclusiveMin && item < exclusiveMax)
                {
                    count += 1;
                }
            }

            return count;
        }
        public static Color getColor(int value)
        {   //This function converts an integer into a color.
            Color myColor;

            switch (value)
            {
                case 0: myColor = Color.Magenta; break;
                case 1: myColor = Color.Brown; break;
                case 2: myColor = Color.Red; break;
                case 3: myColor = Color.Orange; break;
                case 4: myColor = Color.Yellow; break;
                case 5: myColor = Color.Green; break;
                case 6: myColor = Color.Blue; break;
                case 7: myColor = Color.Violet; break;
                case 8: myColor = Color.Gray; break;
                case 9: myColor = Color.White; break;
                case 10: myColor = Color.YellowGreen; break;

                default: myColor = Color.Aqua; break;
            }

            return myColor;
        }
        public static void SaveArray(int[] myArray)
        {
            string name;
            StreamWriter file;

            if (myArray.Length == 0)
                throw new ArgumentException();

            Console.Write("Please choose a filename for the array: ");
            name = Console.ReadLine();


            try
            {
                file = new StreamWriter(String.Format("{0}.txt", name));
                foreach (var item in myArray)
                {
                    file.WriteLine(item);
                }
                file.Close();
            }
            catch
            {
                Console.Write("Error while saving file.");
            }
        }
        public static int[] LoadArray()
        {
            string input;
            StreamReader file;
            int[] myArray;
            List<int> iList = new List<int>();
            int line;

            Console.Write("Enter filename of array or press enter to go back to the main program: ");
            input = Console.ReadLine();

            try
            {
                file = new StreamReader(input);

                while (int.TryParse(file.ReadLine(), out line) == true)
                {
                    iList.Add(line);
                }
                myArray = new int[iList.Count];
                for (int i = 0; i < iList.Count; i++)
                {
                    myArray[i] = iList[i];
                }
                file.Close();
                

            }
            catch (FileNotFoundException)
            { Console.Write("File could not be found.");
                throw new Exception(); }
            catch (Exception)
            { Console.Write("An exception occured."); throw new Exception(); }



            return myArray;
        }
    }
}

