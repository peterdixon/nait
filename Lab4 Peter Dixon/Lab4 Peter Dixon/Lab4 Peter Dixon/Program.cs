using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using Utilities;

namespace Lab4_Peter_Dixon
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Enter the number of grades you want to generate: ";
            int[] grades = new int[0];
            string initializeGradesErrorMessage = "An error occured.";
            double average;
            int maximumGrade;
            int minimumGrade; 
            string choice;
            bool invalidEntryError;
            string invalidEntryMessage = "Please choose a valid option.";
           
           

            do
            {
                Console.WriteLine("Actions available...\n");
                Console.WriteLine("1. Create random array.");
                Console.WriteLine("2. Array stats.");
                Console.WriteLine("3. Draw Histogram.");
                Console.WriteLine("4. Save array. ");
                Console.WriteLine("5. Load array. ");
                Console.WriteLine("q. Exit Program.");
                

                do
                {
                    invalidEntryError = false;
                    Console.Write("\nYour selection: ");
                    choice = Console.ReadLine().ToLower();

                    switch (choice)
                    {
                        case "1":
                            //Create random array
                            grades = CUtilities.GetArray(message);
                            break;
                        case "2":
                            try
                            {
                                //Sort array and display it
                                CUtilities.DisplayArray(grades);
                                //Get array stats
                                maximumGrade = grades.Max();
                                minimumGrade = grades.Min();
                                average = CUtilities.GetAverageOfArray(grades);
                                Console.WriteLine("The minimum value is {0}", minimumGrade);
                                Console.WriteLine("The average value is {0}", average);
                                Console.WriteLine("The maximum value is {0}", maximumGrade);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(initializeGradesErrorMessage);
                                invalidEntryError = true;
                            }
                            
                            break;
                        case "3":
                            try
                            {
                                CUtilities.DrawGradesHistogram(grades);
                            }
                            catch(Exception)
                            {
                                Console.WriteLine(initializeGradesErrorMessage);
                                invalidEntryError = true;
                            }
                            break;
                        case "4":
                            try
                            {
                             CUtilities.SaveArray(grades);
                            }
                            catch
                            {
                                Console.WriteLine(initializeGradesErrorMessage);
                                invalidEntryError = true;
                            }
                            break;
                        case "5":
                            try
                            {
                                grades = CUtilities.LoadArray();                                
                            }

                            catch
                            {
                                invalidEntryError = true;
                            }
                                break;
                        case "q":
                            break;
                        default:
                            Console.WriteLine(invalidEntryMessage);
                            invalidEntryError = true;
                            break;

                    }

                } while (invalidEntryError == true);
            } while (choice != "q");

            CUtilities.Pause("Press any key to exit: ");

        }
    }
}
