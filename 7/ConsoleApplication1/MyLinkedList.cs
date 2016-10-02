using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MyLinkedList<T>: IEnumerable<T>
    {
        private Node<T> First;
        private Node<T> Last;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = First;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }

        }

        public void Insert(T value)
        {
            var node = new Node<T>();
            node.Value = value;

            if (First == null)
            {
                First = node;
                Last = First;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
        }

        public bool Contains(T value)
        {
            foreach (T node in this)
            {
                if (node.Equals(value))
                    return true;
            }

            return false;
        }

        // O(n)
        public MyLinkedList<T> UnionAll(MyLinkedList<T> list)
        {
            // copy all elements from a current list into a result list, if we just assign a current list to result, we will modify a current list as well
            MyLinkedList<T> resultList = GetCopyOfCurrentList();
            resultList.Last.Next = list.First;

            return resultList;
        }

        private MyLinkedList<T> GetCopyOfCurrentList()
        {
            var resultList = new MyLinkedList<T>();
            foreach (var item in this)
            {
                resultList.Insert(item);
            }

            return resultList;
        }

        // O(n^2), we could improve time complexity by using a hash table, but it would increase space complexity
        public MyLinkedList<T> Union(MyLinkedList<T> list)
        {
            var resultList = new MyLinkedList<T>();

            foreach (T item in this)
            {
                if (!resultList.Contains(item))
                    resultList.Insert(item);
            }

            foreach (T item in list)
            {
                if (!resultList.Contains(item))
                    resultList.Insert(item);
            }

            return resultList;
        }

        // O(n^2)
        public MyLinkedList<T>  Intersection(MyLinkedList<T> list)
        {
            var resultList = new MyLinkedList<T>();

            foreach (T item in this)
            {
                if (!resultList.Contains(item) && list.Contains(item))
                    resultList.Insert(item);
            }

            return resultList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
