using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    //Challenge
    //Using the C# language, have the function LongestWord(sen) take the sen parameter being passed 
    // and return the largest word in the string. If there are two or more words that are the same length, 
    // return the first word from the string with that length. Ignore punctuation and assume sen will not be empty. 
    //Sample Test Cases
    //Input:"fun&!! time"
    //Output:"time"

    //Input:"I love dogs"
    //Output:"love"

    class Program
    {
        public static string LongestWord(string sen)
        {
            sen = Regex.Replace(sen, @"[^a-zA-Z ]+", string.Empty);

            string[] words = sen.Split(' ');

            return words.OrderByDescending(s => s.Length).First();
        }


        static void Main(string[] args)
        {
            string str = LongestWord("fun&!! time");
            Console.WriteLine(str);

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
