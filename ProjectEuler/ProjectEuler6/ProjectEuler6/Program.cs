using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Complete

//Sum of Squares: Sum of first ten squares of natural numbers is is 1^2 + 2^2 +... + 10^2 = 385

//Square of sum: Square of the sum of the first ten natural numbers is (1+2+...+10)^2 = 3025.

//Difference is 3025-385 = 2640.

//Find the difference between the Square of Sum and the Sum of Squares for the first 100 natural numbers.
namespace ProjectEuler6
{
    class Program
    {
        static void Main(string[] args)
        {
            int difference = 0;
            //Testcase

            //int greatestN = 10;

            //Real Case
            int greatestN = 100;

            //For testcase, output should be 3025
            int squareOfSum = GetSquareOfSum(greatestN);


            //For testcase, output should be 385
            int sumOfSquare = GetSumofSquares(greatestN);

            difference = squareOfSum - sumOfSquare;
            Console.WriteLine("For the first {1} natural numbers, the difference is {0:N}", difference, greatestN);


            Console.ReadLine();
        }

        static int GetSumofSquares(int upperBound)
        {
            int sum = 0;
            int square = 0;

            for (int i = 1; i <= upperBound; i++)
            {
                square = (i) * (i);
                sum = ((sum) + (square));

            }
            

            Console.WriteLine("The Sum of Squares is {0}", sum);
            return sum;
        }

        static int GetSquareOfSum(int upperBound)
        {
            int sum = 0;
            int square = 0;

            for (int i = 1; i <= upperBound; i++)
            {
                sum = sum + i;
            }

            square = (sum) * (sum);
            Console.WriteLine("The Square of the Sum is: {0}", square);

            return square;
        }

    }
}
