using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Using the C# language, have the function FirstFactorial(num) take the num parameter being passed and return the factorial of it 
//(e.g. if num = 4,
//return (4 * 3 * 2 * 1)). For the test cases, the range will be between 1 and 18. 
//Sample Test Cases
//Input:4
//Output:24

//Input:8
//Output:40320
namespace ConsoleApplication1
{
    class Program
    {
        public static uint FirstFactorial(uint num)
        {
            if (num < 3)
                return num;

            for (uint i = num - 1; i > 1; i--)
            {
                num *= i;
            }

            return num;
        }

        static void Main(string[] args)
        {
            uint input = 18;
            Console.WriteLine(FirstFactorial(input));

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
