/* A Pythagorean triplet is a set of integers a<b<c such that
 *          a^2 + b^2 = c^2
 * 
 * An example is 3^2 + 4^2 = 9+16=25=5^2
 * 
 * There exists exactly one triplet such that a+b+c = 1000
 * Find the product abc.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int c = 3;
            bool done = false;

            //Idea: 3 while loops. One manages each variable. C then B then A.

            //Increase C by 1. Set A= 1 and B=2.
            //If PythSum < C, increase B by 1.
            // If PythSum = C, use Check. If Check succeeds, we are done.
            // 

            //



            //Idea: Given a fixed a, make b rise until Pythsum a,b is greater than or equal to c.
        
            
            while (done == false) 
            {
                
                if (a<b) //Every time the main loop runs, check that a<b. If that's true, we can go and ramp up b.
                {
                    while (PythSum(a, b) < (c * c))
                    {



                        //This section increases b while a remains fixed
                        if (PythSum(a, b) < (c * c))
                        {
                            b++;                       //In the case that lowersum is =, this step is skipped so we dont worry about missing the good one.


                        }
                        else //Occurs only if sumOfSquares = c*c.
                        {
                            if (Check(a, b, c) == true)
                            {
                                Console.WriteLine("We are done! {0}*{1}*{2} = {3} ", a, b, c, (a * b * c));
                                done = true;
                            }
                            break; //this exits the loop.


                        }
                    }

                //Increase a until Pythsum < c*c or =. In the case of <, b is increased until the bubble breaks.
                
                     
                

                }

                 
            }
           

            //This function makes a 3 tuple of a, b, and c and goes through all permutations until a+b+c= 1000;

           
            Console.ReadLine();
        }

        static bool Check(int a, int b, int c)
        {
            bool result = false;
            if (a + b + c == 1000)
            {
                Console.WriteLine("{0} + {1} + {2} = 1000", a, b, c);
                result = true;
            }
            return result;
                
        }
        static void Product(int a, int b, int c)
        {
            int product = a * b * c;

            Console.WriteLine("{0} * {1} * {2} = {3} ", a, b, c, product);

        }
        //Calculate the sum of the squares of A and B, then check if the square root of that sum is an integer.
        static int PythSum(int a, int b)
        {
            int sum = ((a * a) + (b * b));
            return sum;
        }
    }

        
}
