using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //http://www.crazyforcode.com/union-intersection-linked-lists/
        //Given two Linked Lists, create union and intersection lists that contain union and intersection of the elements present in the given lists.
        //Order of elments in output lists doesn’t matter.
        static void Main(string[] args)
        {
            var linkedList1 = new MyLinkedList<int>();
            linkedList1.Insert(1);
            linkedList1.Insert(1);
            linkedList1.Insert(2);
            linkedList1.Insert(3);
            linkedList1.Insert(4);

            var linkedList2 = new MyLinkedList<int>();
            linkedList2.Insert(1);
            linkedList2.Insert(2);
            linkedList2.Insert(5);
            linkedList2.Insert(6);
            linkedList2.Insert(7);
            linkedList2.Insert(8);

            Console.WriteLine("UNIONALL");
            foreach (var item in linkedList1.UnionAll(linkedList2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("UNION");
            foreach (var item in linkedList1.Union(linkedList2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("INTERSECTION");
            foreach (var item in linkedList1.Intersection(linkedList2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
