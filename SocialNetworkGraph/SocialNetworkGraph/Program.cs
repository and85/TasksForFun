using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph
{
    // used https://www.draw.io to draw a diagram
    class Program
    {
        public class Node
        {
            public int VertexIndex { get; set; }
            public string Name { get; set; }

            private List<Node> _friends;
            public List<Node> Friends
            {
                get
                {
                    if (_friends == null)
                        _friends = new List<Node>();
                    return _friends;
                }
            }
        }

        private static Node _node1 = new Node() { VertexIndex = 1, Name = "Anna" };
        private static Node _node2 = new Node() { VertexIndex = 2, Name = "Bill" };
        private static Node _node3 = new Node() { VertexIndex = 3, Name = "Bob" };
        private static Node _node4 = new Node() { VertexIndex = 4, Name = "Mickey Mouse" };
        private static Node _node5 = new Node() { VertexIndex = 5, Name = "Mr. Bean" };
        private static Node _node6 = new Node() { VertexIndex = 6, Name = "Darek" };
        private static Node _node7 = new Node() { VertexIndex = 7, Name = "Anna" };
        private static Node _node8 = new Node() { VertexIndex = 8, Name = "Mr. Weirdo" };

        static void Main(string[] args)
        {            
            SetRelations();

            Console.WriteLine("Suggested friends, max depth 2:");
            foreach (var friend in SuggestFriendsMaxDepth(_node1, 2))
            {
                Console.WriteLine($"{friend.VertexIndex} {friend.Name}");
            }

            Console.WriteLine("Suggested friends, max depth 3:");
            foreach (var friend in SuggestFriendsMaxDepth(_node1, 3))
            {
                Console.WriteLine($"{friend.VertexIndex} {friend.Name}");
            }
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static void SetRelations()
        {
            _node1.Friends.Add(_node2);
            _node1.Friends.Add(_node4);
            _node1.Friends.Add(_node3);
            _node2.Friends.Add(_node1);
            _node2.Friends.Add(_node4);
            _node3.Friends.Add(_node1);
            _node3.Friends.Add(_node5);
            _node3.Friends.Add(_node6);
            _node4.Friends.Add(_node1);
            _node4.Friends.Add(_node2);
            _node4.Friends.Add(_node7);
            _node5.Friends.Add(_node3);
            _node6.Friends.Add(_node3);
            _node6.Friends.Add(_node7);
            _node7.Friends.Add(_node4);
            _node7.Friends.Add(_node6);
            _node7.Friends.Add(_node8);
            _node8.Friends.Add(_node7);
        }

        public static List<Node> FindFriends(Node node)
        {
            return node.Friends;
        }

        /// <summary>
        /// Suggests friends to a user according to a required Depth.         
        /// </summary>        
        public static HashSet<Node> SuggestFriendsMaxDepth(Node node, int depth)
        {
            var resultFriends = new HashSet<Node>();
            return SuggestFriendsMaxDepth(node, node, depth, resultFriends);
        }

        /// <summary>
        /// Suggests friends only from required depth, 
        /// i.e. if depth is 3 for "1 Anna". Algorithm shouldn't suggest 
        /// Mr. Bean and Darek (because for them depth is 2). 
        /// Anna 7 should be excluded because it could be reached either in 2 or 3 steps.
        /// Mr. Weirdo should be suggested as a friend, because the shortest path to him is 3
        /// </summary>        
        public static HashSet<Node> SuggestFriendsStrictDepth(Node node, int depth)
        {
            return new HashSet<Node>();
        }

        private static HashSet<Node> SuggestFriendsMaxDepth(Node node, Node initialRoot, int depth, HashSet<Node> resultFriends)
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
