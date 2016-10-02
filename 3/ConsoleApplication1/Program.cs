using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // more sulutions here: https://habrahabr.ru/post/261159/

        // Write a function to print nth number in Fibonacci series?
        static void Main(string[] args)
        {
            //int number = GetFibonacciNumberRecursive(int.MaxValue);
            //int number = FibonacciSeriesIterative2(int.MaxValue);
            int number = FibonacciSeriesIterative(int.MaxValue);
            Console.WriteLine(number);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        static int _counter = 0;
        private static Dictionary<int, int> _dictionary = new Dictionary<int, int>();

        // De facto we have O(m) time complexity because of memorization, but we also have O(n) space complexity
        private static int GetFibonacciNumberRecursive(int n)
        {
            if (n < 2) return n;
            
            // memorisation
            if (_dictionary.ContainsKey(n))
            {
                return _dictionary[n];
            }

            _counter++;
            int sum = GetFibonacciNumberRecursive(n - 1) + GetFibonacciNumberRecursive(n - 2);
            _dictionary.Add(n, sum);

            return sum;
        }

        // in the article it's called Dynamic :)
        private static int FibonacciSeriesIterative2(int n)
        {
            int a = 0;
            int b = 1;
            int c = 0;

            foreach (int i in Enumerable.Range(2, n))
            {
                c = a + b;
                a = b;
                b = c;
            }
            
            return c;
        }

        // O(n) time complexity
        static int FibonacciSeriesIterative(int n)
        {
            if (n < 2) return n;  

            int firstnumber = 0, secondnumber = 1, result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }
            return result;
        }
    }
}
