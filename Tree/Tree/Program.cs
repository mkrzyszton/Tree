using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Node
    {
        public string? Name;
        public Dictionary<Node, Node> Nodes = new Dictionary<Node, Node>();
        public Dictionary<Node, Node> Edges = new Dictionary<Node, Node>();

        public Node(string? name)
        {
            Name = name;
        }

        public void addNode(Node child, Node? parent)
        {
            if (parent == null)
            {
                Nodes.Add(child, child);
            }
            else
            {
                Nodes.Add(child, parent);
                Edges.Add(child, parent);
            }
        }

        public void removeNode(Node node)
        {
            foreach (KeyValuePair<Node, Node> pair in Nodes)
            {
                if (pair.Value == node | pair.Key == node)
                {
                    Nodes.Remove(pair.Key);
                    Edges.Remove(pair.Key);
                }
            }
        }

        public void countNodes()
        {
            Console.WriteLine($"Node number: {Nodes.Count}");
        }

        public void insertEdge(Node lowerNode, Node upperNode)
        {
            Edges.Add(lowerNode, upperNode);
        }

        public void removeEdge(Node lowerNode)
        {
            foreach (KeyValuePair<Node, Node> edge in Edges)
            {
                if (edge.Value == lowerNode | edge.Key == lowerNode)
                {
                    Edges.Remove(lowerNode);
                }
            }
        }

        public void countEdges()
        {
            Console.WriteLine($"Edge number: {Edges.Count}");
        }

        public void Display()
        {
            foreach (KeyValuePair<Node, Node> node in Nodes)
            {
                if (node.Value.Name == node.Key.Name)
                {
                    Console.WriteLine($"Node: {node.Key.Name}");
                }
                else
                {
                    Console.WriteLine($"Child: {node.Key.Name} Parent: {node.Value.Name}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();

            foreach (KeyValuePair<Node, Node> edge in Edges)
            {
                Console.WriteLine($"Edge between: {edge.Key.Name} - {edge.Value.Name}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node node = new(null);
            Node n = new("n");
            Node n1 = new("n1");
            Node n2 = new("n2");
            Node n3 = new("n3");
            Node n4 = new("n4");
            Node n5 = new("n5");
            Node n6 = new("n6");

            // (Child, Parent)
            node.addNode(n, null);
            node.addNode(n1, n);
            node.addNode(n2, n);
            node.addNode(n5, n2);
            node.addNode(n6, n2);
            node.addNode(n3, null);
            node.addNode(n4, n3);

            node.insertEdge(n, n3);
            node.removeNode(n2);
            node.removeEdge(n1);

            node.Display();
            node.countNodes();
            node.countEdges();
        }
    }
}
