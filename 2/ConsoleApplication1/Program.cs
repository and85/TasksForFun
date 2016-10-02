using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // How to find all pairs of elements in an integer array, whose sum is equal to a given number? 
        static void Main(string[] args)
        {
            var array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            FindNumbers(array, 6);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static void FindNumbers(int[] array, int number)
        {
            for (int i=0; i<array.Length; i++)
            for (int j=i+1; j<array.Length; j++)
            {
                if (array[i] + array[j] == number)
                {
                    Console.WriteLine(array[i]);
                    Console.WriteLine(array[j]);
                }
            }
        }
    }
}

