using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace LAB02_Peter_Dixon
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //There are three components to the resistor: the resistor, the wire, and the colored bands.

            //Randomly generate the band resistance   
            Random generator = new Random();                                                                 //Generates random values
            int firstBandInt = generator.Next(1, 10);                                                        //Generates the first band digit
            int secondBandInt = generator.Next(0, 10);                                                       //Generates the second band digit
            int thirdBandInt = generator.Next(0, 7);                                                         //Generates the third band digit
            
            
            //Get colors of all three bands
            Color firstBandColor = getBandColor(firstBandInt);                                               //color of the first band
            Color secondBandColor = getBandColor(secondBandInt);                                             //color of the second band 
            Color thirdBandColor = getBandColor(thirdBandInt);                                               //color of the third band

           
            
//These variables are used for Drawing.
            //The GDI Drawer Window Size Variables.
            int windowWidth = 800;                                                                           //The width of the GDI drawer window
            int windowHeight = 600;                                                                          //the height of the GDI drawer window

            //Initialize the GDI drawer.
            CDrawer drawer = new CDrawer(windowWidth, windowHeight);

            //Wire Drawing variables
            int wireWidth = 600;                                                                             //the width of the wire on the resistor
            int wireHeight = 20;                                                                             //the height of the wire on the resistor
            int wireYStart = windowHeight / 2 - ((1 / 2) * wireHeight);                                      //Starting X coordinate of the wire
            int wireXstart = windowWidth / 8;                                                                //Starting Y coordinate of the wire

            //Resistor Drawing Variables.
            int resistorWidth = 500;                                                                         //The width of the resistor
            int resistorHeight = 200;                                                                        //the height of the resistor
            int numBands = 6;                                                                                //the number of bands inside the resistor, including unused ones.
            int resistorBorderThickness = 5;                                                                 //Thickness of border of resistor. Distinguishes the resistor from the background.
            int bandBorderThickness = 2;                                                                     //This border distinguishes the band from the resistor.      
            int resistorXstart = wireXstart + (wireWidth - resistorWidth) / 2;                               //starting X coordinate of the resistor
            int resistorYStart = (wireHeight / 2) + wireYStart - (resistorHeight / 2);                       //starting Y coordinate of the resistor
            int bandHeight = resistorHeight - 2*resistorBorderThickness;                                     //Determines the height of each band.
            int bandWidth = (resistorWidth - (1 + numBands * resistorBorderThickness)) / numBands;           //Determines the width of each band.

            //Text on GDI window
            string message = "Guess the Resistor Value";                                                     //String containing the message on the GDI window
            float textSize = 20f;                                                                            //font size of text
            int textHeight = (int)textSize + 1;                                                              //Height of text window
            int textWidth = ((int)textSize + 1) * message.Length;                                            //Width of text window
            int textXstart = (windowWidth / 2) - (((int)textSize+1) * message.Length / 2);                   //Starting x coordinate of text window
            int textYstart = (windowHeight / 5);                                                             //Starting y coordinate of text window.

            //Time and Score Variables
            long start;                                                                                      //The time at which the user is given the diagram.
            long end;                                                                                        //The time at which the user enters their answer
            double elapsedTime;                                                                              //The amount of time that the user has spent answering the question.
            double score;                                                                                    //The user's score.
            double guess;                                                                                    //The user's guess
            double answer = (double)(firstBandInt * 10 + secondBandInt) * Math.Pow(10, thirdBandInt);        //The total resistance of the band.


            //Write the Resistance down (for cheating)
            //Console.WriteLine("The bands are {0} {1} {2}, giving a resistance of {3:F2} ohms", firstBandInt, secondBandInt, thirdBandInt, resistance);

            //Drawing on the GDI window.
            //Add the bars of the resistor.
            drawer.AddRectangle(wireXstart, wireYStart , wireWidth, wireHeight, Color.Gray);
            drawer.AddRectangle(resistorXstart, resistorYStart, resistorWidth, resistorHeight, Color.Red);

            //Draw the three bars inside of the resistor.
            drawer.AddRectangle(resistorXstart + 0* bandWidth + 1 * resistorBorderThickness, resistorYStart + resistorBorderThickness, bandWidth, bandHeight, firstBandColor, bandBorderThickness, Color.Black);
            drawer.AddRectangle(resistorXstart + 1 * bandWidth + 2 * resistorBorderThickness, resistorYStart + resistorBorderThickness, bandWidth, bandHeight, secondBandColor,bandBorderThickness,Color.Black);
            drawer.AddRectangle(resistorXstart + 2 * bandWidth + 3 * resistorBorderThickness, resistorYStart + resistorBorderThickness, bandWidth, bandHeight, thirdBandColor, bandBorderThickness, Color.Black);

            //Fill the rest of the resistor with a black void.
            drawer.AddRectangle(resistorXstart + 3 * bandWidth + 4 * resistorBorderThickness, resistorYStart + resistorBorderThickness, resistorWidth - (3 * bandWidth + 5 * resistorBorderThickness), bandHeight, Color.Black, bandBorderThickness, Color.Black);

            //Place Text on GDI WIndow
            drawer.AddText(message, textSize, textXstart, textYstart, textWidth, textHeight, Color.Gray);

//Console Window
            //Set the background of the Console Window as white, the foreground as blue.
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            //Print the title
            Console.WriteLine("\t\t\tResistor Value Game");
            Console.Write("\nThis program will draw a random resistor on the graphics window.");
            Console.Write("\nTry to determine the value of the resistor. You will be timed and");
            Console.Write("\npoints will be awarded.");

            Console.Write("\n\nLook at the resistor in the graphics window...");

//User Input and Scoring
            



//Ask user for guess until they get it right or they've been trying for more than 20 seconds.
            guess = 0;
            start = System.Environment.TickCount;
            while (guess != answer)
            {

                Console.Write("Enter your guess for the resistor value in ohms: ");
                double.TryParse(Console.ReadLine(), out guess);

                //Display Message to User if they got answer wrong.
                if (guess != answer)
                {
                    Console.Write("Incorrect. Please try again.");
                }

                //Break if they've taken more than 20 seconds.
                if( ((double)((System.Environment.TickCount-start)/1000.0) > 20.0))
                {
                    break;
                }
                
                
               
            }
            //double.TryParse(Console.ReadLine(), out guess);
            end = System.Environment.TickCount;
            elapsedTime = (double)((end - start) / 1000.0);
            
            //Test values
            //elapsedTIme = 5.0; // score = 1000
            //elapsedTime = 17.469; //score is 651
            //elapsedTime = 21.0; //score =0 

            //If the answer was correct, determine which score to give them
            if (guess == answer)
            {
                //Confirm to the user that their answer is correct and the amount of time elapsed.
                Console.WriteLine("\nYour guess of {0:F2} was correct!", guess);
                Console.WriteLine("\nYou guessed it in {0:F3} seconds.", elapsedTime);

                //Award full points if the time taken was less than 10 seconds.
                if (elapsedTime < 10.0)
                {
                    score = 1000.0;
                    Console.WriteLine("\nYou have been awarded {0} out of 1000 points.", score);
                }
                //Award points if 10.0< elapsed time < 20.0
                else if (elapsedTime < 20.0)
                {
                    score = (1000.0 - ((elapsedTime) * 20.0));
                    Console.WriteLine("\nYou have been awarded {0:F0} out of 1000 points.", score);
                }

                //Award 0 if elapsed time > 20.0.
                else
                {
                    score = 0;
                    Console.WriteLine("\nYou have been awarded {0} out of 1000 points.", score);
                    Console.WriteLine("\nI'm sorry, you took too long to answer.");
                }
            }

            //Message if the user could not get the correct answer in time.
            else
            {
                Console.WriteLine("\nYou could not get the correct answer in time. The correct resistance is {0:F2}. You were awarded a score of 0 points out of 1000.", answer);
            }

            

            //End the Program
            Console.WriteLine("\nPress any key to exit the program.");
            Console.ReadKey();
            
        }
        
        //This function takes a one digit integer and returns the Color corresponding to it.
        
        static Color getBandColor(int bandInt)
        {
            Color bandColor = Color.Aqua;

            switch (bandInt)
            {
                case 0: bandColor = Color.Black; break;
                case 1: bandColor = Color.Brown; break;
                case 2: bandColor = Color.Red; break;
                case 3: bandColor = Color.Orange; break;
                case 4: bandColor = Color.Yellow; break;
                case 5: bandColor = Color.Green; break;
                case 6: bandColor = Color.Blue; break;
                case 7: bandColor = Color.Violet; break;
                case 8: bandColor = Color.Gray; break;
                case 9: bandColor = Color.White; break;
            }

            return bandColor;
        }
    }
}
