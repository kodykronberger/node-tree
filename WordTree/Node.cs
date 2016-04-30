using System.Collections.Generic;
using System.Linq;

namespace WordTree
{
    public class Node
    {
        public string Value { get; set; }
        public List<Node> Children { get; set; }
        public Node()
        {
            this.Children = new List<Node>();
        }
        public Node(string value)
            : this()
        {
            this.Value = value;
        }

        public static Node AddWord(Node firstNode, string word)
        {
            Node currentNode = firstNode;
            Node nextNode;

            foreach (char c in word.ToLower())
            {
                // Get char value
                string value = c.ToString();

                // Find a node that contains the current value
                Node foundValue = currentNode.Children.FirstOrDefault(n => n.Value == value);

                // If node was found, no need to add duplicate nodes. 
                // Else, add a new node with the char value
                if (foundValue != null)
                {
                    currentNode = foundValue;
                }
                else
                {
                    nextNode = new Node(c.ToString());
                    currentNode.Children.Add(nextNode);
                    currentNode = nextNode;
                }
            }

            // Return parent node
            return firstNode;
        }
    }
}
