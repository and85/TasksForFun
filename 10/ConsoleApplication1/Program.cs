using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Challenge
//Using the C# language, have the function FirstReverse(str) take the str parameter being passed and return 
//the string in reversed order. 
//Sample Test Cases
//Input:"coderbyte"
//Output:"etybredoc"

//Input:"I Love Code"
//Output:"edoC evoL I"
namespace ConsoleApplication1
{
    class Program
    {
        public static string FirstReverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        static void Main(string[] args)
        {
            string input = "I Love Code";
            string reverse = FirstReverse(input);

            Console.WriteLine(reverse);

            Console.ReadLine();
        }
    }
}
