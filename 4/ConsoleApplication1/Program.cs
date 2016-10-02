using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // How to calculate factorial using recursion in C#?
        // 5! = 5*4*3*2*1 = 120;
        static void Main(string[] args)
        {
            //int number = FactorialRecursive(5);
            int number = FactorialLoop(5);
            Console.WriteLine(number);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static int FactorialRecursive(int n)
        {
            if (n == 1) return 1;

            return n * FactorialRecursive(n - 1);
        }

        private static int FactorialLoop(int n)
        {
            int result = 1;
            for (int i=1; i <= n; i++)
            {
                result = result * i;
            }

            return result;
        }
    }
}
