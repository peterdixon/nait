//The sum of Primes below 10 is 17

//What is the sum of primes below 2000000?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Project_10
{
    class Program
    {
        

        static bool CheckPrime(long dividend)
        {
            long divisor = 3;

            while ( divisor < (long)Math.Ceiling(Math.Sqrt(dividend)) )
            {
                long remainder = dividend % divisor;
                if (remainder == 0)
                {
                    return false;

                }
                else
                {
                    divisor+=2;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            long[] primes;
            long value = 3;
            bool primeness;

            primes = new long[10001];

            //The 10000th member of primes is the 10001th prime.

            int index = 0;
            while (index < 10001)
            {

                primeness = CheckPrime(value);
                switch (primeness)
                {
                    case false:  break;
                    case true: primes[index] = value; index++;  break;
                }
                value += 2;


            }
            Console.WriteLine(primes[10000]);

            Console.ReadKey();

        }
      

          
        }

}

