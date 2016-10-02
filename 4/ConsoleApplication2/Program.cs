using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    // Write a program to check if a String contains another String e.g. indexOf()?
    /*
     * You need to write a function to search for the existence of a string (target) in another string (source). T
     * he function takes two strings as the input and returns the index where the second string is found. 
     * If the target string cannot be found, then return -1. 
     * If you are a Java developer, then you can related its behavior to indexOf() method from java.lang.String class. 
     * This question is also asked as Code and algorithm to check if a given short string is a substring of a main string. 
     * Can you get a linear solution (O(n)) if possible?
    */
    class Program
    {
        static void Main(string[] args)
        {
            int index = IndexOf(@"A big brown fox jumped on a rabbit", "fox");
            Console.WriteLine(index);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        //  O(n) time complexity
        private static int IndexOf(string inputString, string subString)
        {
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrEmpty(subString) || subString.Length > inputString.Length)
                return -1;

            int k = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] != subString[k])
                    k = 0;
                else
                    k++;

                if (k == subString.Length)
                    return i - subString.Length + 1;
            }

            return -1;
        }
    }
}
