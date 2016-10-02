using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    /*
     * Given an unsorted array which has a number in the majority 
     * (a number appears more than 50% in the array), find that number?
     * 
     * http://www.csharpstar.com/csharp-program-to-find-majority-element-in-an-unsorted-array/
    */

    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[6];
            array[0] = 1;
            array[1] = 2;
            array[2] = 2;
            array[3] = 2;
            array[4] = 1;
            array[5] = 2;

            //int number = FindNumber(array);
            int number = GetMajorityElement(array);
            //int number = GetMajorityElementVersion2(array);
            Console.WriteLine(number);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        // similar to optimal implementation, however operations with Dictionary are not efficient.
        static int FindNumber(int[] array)
        {
            if (array.Length == 1)
                return array[0];
            
            var requiredN = (int)Math.Ceiling((double)array.Length / 2);

            var entries = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!entries.ContainsKey(array[i]))
                {
                    entries.Add(array[i], 1);
                }
                else
                {
                    int value;
                    entries.TryGetValue(array[i], out value);
                    value++;

                    if (value == requiredN)
                        return array[i];
                    
                    entries.Remove(array[i]);
                    entries.Add(array[i], value);
                }
            }

            return int.MinValue;
        }
        
        // optimal implementation
        public static int GetMajorityElement(params int[] x)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int majority = x.Length / 2;

            //Stores the number of occcurences of each item in the passed array in a dictionary
            foreach (int i in x)
                if (d.ContainsKey(i))
                {
                    d[i]++;
                    //Checks if element just added is the majority element
                    if (d[i] > majority)
                        return i;
                }
                else
                    d.Add(i, 1);
            //No majority element
            throw new Exception("No majority element in array");
        }

        // Linq based implementation which I believe is less efficient
        public static int GetMajorityElementVersion2(params int[] x)
        {
            if (x.Any(i => x.Count(j => j == i) > x.Length / 2))
            {
                return x.FirstOrDefault(i => x.Count(j => j == i) > x.Length / 2);
            }

             throw new Exception("No majority element in array");
        }
    }
}


