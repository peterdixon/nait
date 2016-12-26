using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Changing this to Euler1.
//Find the sum of the multiples of 3 and 5 that are less than some given N.
    
namespace TDD_Euler12
{
    public interface iMultiplesGenerator
    {
        List<int> Generate(int integer, int upperbound);
    }

    public class MultiplesMaker : iMultiplesGenerator
    {
        // Explicit interface member implementation: 
        List<int> iMultiplesGenerator.Generate(int integer, int upperbound)
        {
            List<int> multiples = new List<int>;
            for (int i = 0; i < 1+upperbound/integer; i++)
            {
                multiples.Add(i * integer);
            }

            return multiples;
        }

        static void Main()
        {
            // Declare an interface instance.
            iMultiplesGenerator obj = new MultiplesMaker();

            // Call the member.
            obj.Generate(3,100);
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
