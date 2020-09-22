using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree\n");

            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(75);
            binaryTree.Insert(57);
            binaryTree.Insert(90);
            binaryTree.Insert(32);
            binaryTree.Insert(7);
            binaryTree.Insert(44);
            binaryTree.Insert(60);
            binaryTree.Insert(86);
            binaryTree.Insert(93);
            binaryTree.Insert(99);
            binaryTree.Insert(100);



            //binaryTree.InOrderTraversal();
            //Console.WriteLine("_____PREORDER TRAVERSAL____________");
            //binaryTree.PreOrderTraversal();


            //var node = binaryTree.FindRecursive(93);

            //if(node != null)
            //{
            //    Console.WriteLine($"Found Node: {node.Data}");
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
            //}


            // Console.WriteLine($"Min of the Tree = {binaryTree.Min()} ");
            //Console.WriteLine($"Max of the Tree = {binaryTree.Max()} ");
            //binaryTree.PreOrderTraversal();
            //var serialized = binaryTree.Serialize();

            //var deserialized = binaryTree.Deserialize(serialized);

            //deserialized.PreOrderTraversal();

           var hasPath =  binaryTree.hasPathSum(190);
            //Console.WriteLine($"No Of Leafs of the Tree = {binaryTree.Serialize()} ");

        }
    }
}
