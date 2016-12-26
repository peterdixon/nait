using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Project Euler Question 5 - Complete
            //What is the smallest number that is evenly divisible by all numbers from 1-20 inclusive?
            //2520 is the smallest number that is divisible by all digits 1-10

            /*
            //Test 1
            //Uncomment for test case.
            int dividend = 2520;
            int maxDivisor = 10;

            //Expected output: 2520 will print.
            
            DivisionTest(dividend, maxDivisor);
            
    */
            GenerateDividends();
            Console.ReadLine();


        }

        static bool DivisionTest(int dividendParameter, int upperBound)
        {
            int remainder = 0;
            bool DivisionTestResult = false;
 
            for (int divisor = 1;  divisor <= upperBound; divisor++)
            {

                //Test 2: Comment out to see which divisor stops the loop.
                //Console.WriteLine(divisor);
                remainder = dividendParameter % divisor;
                
                if (remainder != 0)
                {
                    DivisionTestResult = true;
                    return DivisionTestResult;
                }
            }

            //If the loop runs to the end, this line will print the dividend
            //Expected runtime is 9 seconds
            Console.WriteLine(dividendParameter);
            return DivisionTestResult;
           
            // end GenerateDividends.
           
            
        }
        
        static void GenerateDividends()
        {
            /*
            int dividend = 2520;
            int maxDivisor = 20;
            bool KeepGoing = true;
            */

            
             int dividend = 2520;
             int maxDivisor = 20;
             bool KeepGoing = true;
             

            while (KeepGoing == true)
            {
                
                KeepGoing = DivisionTest(dividend, maxDivisor);
                dividend += 1;
            }


        }
        
    }
}
