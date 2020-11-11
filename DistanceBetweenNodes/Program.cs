using System;
using static DistanceBetweenNodes.Program.BinaryTree;

namespace DistanceBetweenNodes
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            root = new Node(5);
            root.left = new Node(3);
            root.right = new Node(6);
            root.left.left = new Node(2);
            root.left.right = new Node(4);
            root.left.left.left = new Node(1);
            root.right.right = new Node(7);
            root.right.right.right = new Node(8);
            Console.WriteLine(BinaryTree.distance(root,1,4));
            Console.ReadLine();

        }
        public static class BinaryTree
        {
            public class Node
            {
                public Node left;
                public Node right;
                public int value;
                public Node(int key)
                {
                    left = null;
                    right = null;
                    value = key;
                }
            }
            public static int distance(Node node,int start, int end)
            {
                if(node==null)
                {
                    return -1;
                }
                Node lca = findLCA(node, start, end);
                if(lca==null)
                {
                    return -1;
                }
                int d1= distancefromLCA(lca, start, 0);
                int d2= distancefromLCA(lca, end, 0);
                return d1+d2;

            }
            public static int distancefromLCA(Node node,int val,int distance)
            {
                if(node==null)
                {
                    return -1;
                }
                if(node.value==val)
                {
                    return distance;
                }
                int d = distancefromLCA(node.left, val, distance+1);
                if (d != -1)
                {
                    return d;
                }

                d = distancefromLCA(node.right, val, distance+1);
                return d;
            }
            public static Node findLCA(Node node,int n1,int n2)
            {
                if(node==null)
                {
                    return null;
                }
                if(node.value==n1 || node.value==n2)
                {
                    return node;
                }
                Node leftLCA = findLCA(node.left, n1, n2);
                Node rightLCA = findLCA(node.right, n1, n2);

                if(leftLCA!=null && rightLCA!=null)
                {
                    return node;
                }
                return leftLCA == null ? rightLCA : leftLCA;
            }
        }
        
    }
}
