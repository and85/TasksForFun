using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //http://www.geeksforgeeks.org/sort-a-stack-using-recursion/
    //Given a stack, sort it using recursion. Use of any loop constructs like while, for..etc is not allowed.
    //We can only use the following ADT functions on Stack S:
    //is_empty(S)  : Tests whether stack is empty or not.
    //push(S)	     : Adds new element to the stack.
    //pop(S)	     : Removes top element from the stack.
    //top(S)	     : Returns value of the top element.Note that this
    //                function does not remove element from the stack.
    //    Example:

    //Input:  -3  <--- Top
    //        14 
    //        18 
    //        -5 
    //        30 

    //Output: 30  <--- Top
    //        18 
    //        14 
    //        -3 
    //        -5
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(30);
            stack.Push(-5);
            stack.Push(18);
            stack.Push(14);
            stack.Push(-3);

            stack = SortStack(stack);

            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static Stack<int> SortStack(Stack<int> stack)
        {
            return null;
        }
    }
}
