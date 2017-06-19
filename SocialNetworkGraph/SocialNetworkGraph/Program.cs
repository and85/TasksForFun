using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph
{
    class Program
    {
        public class Node
        {
            public int VertexIndex { get; set; }

            private List<Node> _friend;
            public List<Node> Friends
            {
                get
                {
                    if (_friend == null)
                        _friend = new List<Node>();
                    return _friend;
                }
            }
        }

        static void Main(string[] args)
        {
            var node1 = new Node() { VertexIndex = 1 };
            var node2 = new Node() { VertexIndex = 2 };
            var node3 = new Node() { VertexIndex = 3 };
            var node4 = new Node() { VertexIndex = 4 };
            var node5 = new Node() { VertexIndex = 5 };
            var node6 = new Node() { VertexIndex = 6 };
            var node7 = new Node() { VertexIndex = 7 };
            var node8 = new Node() { VertexIndex = 8 };

            node1.Friends.Add(node2);
            node1.Friends.Add(node3);
            node1.Friends.Add(node6);
            node2.Friends.Add(node1);
            node2.Friends.Add(node3);
            node3.Friends.Add(node1);
            node3.Friends.Add(node2);
            node3.Friends.Add(node4);
            node3.Friends.Add(node5);
            node4.Friends.Add(node3);
            node4.Friends.Add(node5);
            node5.Friends.Add(node3);
            node5.Friends.Add(node4);
            node5.Friends.Add(node7);
            node6.Friends.Add(node1);
            node6.Friends.Add(node7);
            node7.Friends.Add(node5);
            node7.Friends.Add(node6);
            node7.Friends.Add(node8);
            node8.Friends.Add(node7);

            //SuggestFriends(node2, 4);
            var resultFriends = new HashSet<Node>();
            SuggestFriends(node2, node2, 3, resultFriends);

            foreach (var friend in resultFriends)
            {
                Console.WriteLine(friend.VertexIndex);
            }
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        public static List<Node> FindFriends(Node node)
        {
            return node.Friends;
        }

        /// <summary>
        /// Suggests friends to a user according to a required Depth. 
        /// if depth is 3, for node2 we should return 4, 5, 6, 7 but not 8
        // if depth is 2, for node2 we should return 6, 5, 4
        /// </summary>
        //private static HashSet<Node> _resultFriends = new HashSet<Node>();

        public static HashSet<Node> SuggestFriends(Node node, Node initialRoot, int depth, HashSet<Node> resultFriends)
        {
            if (depth == 0)
            {
                return RemoveOddNodes(initialRoot, resultFriends); 
            }

            foreach (var friend in node.Friends)
            {
                SuggestFriends(friend, initialRoot, depth - 1, resultFriends);
                resultFriends.Add(friend);
            }
            
            return RemoveOddNodes(initialRoot, resultFriends); 
        }

        private static HashSet<Node> RemoveOddNodes(Node root, HashSet<Node> resultFriends)
        {
            // exclude a root itself and it's direct friends from a final output
            resultFriends.Remove(root);
            foreach (var item in root.Friends)
            {
                resultFriends.Remove(item);
            }

            return resultFriends;
        }
    }
}
