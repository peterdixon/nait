using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_Problem_9_Version_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitLoop = false;
           

            for (int A = 1; A < 333; A++)
            {
                
                for(int B = A+1; B < 1000-B-A; B++) //Guarantees that A < B < C
                {
                    int C = 1000 - B - A; //Guarantees A+B+C = 1000;

                    if (PythSum(A, B) == (C*C))
                    {
                        Console.WriteLine("{0}*{1}*{2} = {3}", A, B, C, (A * B * C));
                        exitLoop = true;
                        break;
                    }
                    
                }
                if (exitLoop == true)
                {
                    break;
                }





            }

            Console.ReadLine();
        }

        static int PythSum(int a, int b)
        {
            int sum = (a * a) + (b * b);
            return sum;
        }

        
        
        

    }


}
