using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class TreeNode
    {

        public TreeNode(int data, TreeNode leftNode = null, TreeNode rightNode = null)
        {
            this.Data = data;
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }

        

        public int? Data { get; set; }
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }


        /// <summary>
        /// Binary Tree;
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int value)
        {

            if (value > Data)
            {
                if(RightNode == null)
                {
                    var newRightNode = new TreeNode(value);
                    this.RightNode = newRightNode;
                }
                else
                {
                    this.RightNode.Insert(value);
                }
                
            }
            else
            {
                if(LeftNode == null)
                {
                    var newLeftNode = new TreeNode(value);
                    this.LeftNode = newLeftNode;
                }
                else
                {
                    this.LeftNode.Insert(value);
                }
            }

        }


        /// <summary>
        /// InOrder Traversal = l,n,r
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTraversal()
        {       

            if(LeftNode != null)
            {
                LeftNode.InOrderTraversal();
            }

            Console.WriteLine(Data + "-->");

            if(RightNode != null)
            {
                RightNode.InOrderTraversal();
            }
        }


        //PreOrder = n,l,r
        public void PreOrderTraversal()
        {
            Console.WriteLine(Data + "-->");

            if(LeftNode != null)
            {
                LeftNode.PreOrderTraversal();
            }

            if(RightNode != null)
            {
                RightNode.PreOrderTraversal();
            }
            
        }

        public TreeNode Find(int val)
        {
            TreeNode root = this;
            while(root != null)
            {
                if (root.Data == val)
                    return root;


                if (val < root.Data)
                {
                    root = root.LeftNode;
                }
                else
                {
                    root = root.RightNode;
                }
            }
            return null;
        }

        public TreeNode FindRecursive(int val)
        {
            var root = this;

            if (val == root.Data)
                return root;

            if(val < root.Data && root.LeftNode != null)
            {
               root =  root.LeftNode.FindRecursive(val);
            }
            else if(val > root.Data && root.RightNode != null)
            {
               root =  root.RightNode.FindRecursive(val);
            }
            else
            {
                return null;
            }

            return root;
        }


        public int Height()
        {
            var root = this;

            if (root == null)
                return 0;

            return Height2();

          
        }


        public int Height2()
        {
            //return 1 when leaf node is found
            if (this.LeftNode == null && this.RightNode == null)
            {
                return 1; //found a leaf node
            }

            int left = 0;
            int right = 0;

            //recursively go through each branch
            if (this.LeftNode != null)
                left = this.RightNode.Height2();
            if (this.LeftNode != null)
                right = this.RightNode.Height2();

            //return the greater height of the branch
            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }

        }

        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;          

            return 1 +  Math.Max(Helper(node.LeftNode), Helper(node.RightNode));
        }

        public int? MinValue()
        {

            var root = this;         

            if (root == null)
                return null;

            if (root.LeftNode == null)
                return root.Data;

            int min = root.Data.Value;

            while(root.LeftNode != null)
            {
                int m = root.LeftNode.Data.Value;

                min = Math.Min(m, min);

                root = root.LeftNode;
            }

            return root.Data;
        }

        public int? MaxValue()
        {

            var root = this;

            if (root == null)
                return null;

            if (root.RightNode == null)
                return root.Data;

            int min = root.Data.Value;

            while (root.RightNode != null)
            {
                int m = root.RightNode.Data.Value;

                min = Math.Min(m, min);

                root = root.RightNode;
            }

            return root.Data;
        }


        public int? MinRecursive()
        {
            
            if (this.LeftNode == null)
                return this.LeftNode.Data;

            return MinHelper(this);
        }


        public int? MinHelper(TreeNode node)
        {
            if (node.LeftNode == null)
                return node.Data;

            return MinHelper(node.LeftNode);
        }

        public int? MaxRecursive()
        {

            if (this.RightNode == null)
                return this.RightNode.Data;

            return MaxHelper(this);
        }


        public int? MaxHelper(TreeNode node)
        {
            if (node.RightNode == null)
                return node.Data;

            return MaxHelper(node.RightNode);
        }

        public int NumberOfLeafs()
        {
            if (this.RightNode == null && this.LeftNode == null)
                return 1;

            var rightLeafs = 0;
            var leftLeafs = 0;

            if (this.RightNode != null)
            {
                rightLeafs = this.RightNode.NumberOfLeafs();
            }

            if (this.LeftNode != null)
            {
                leftLeafs = this.LeftNode.NumberOfLeafs();
            }

            return rightLeafs + leftLeafs;
        }


        public  bool IsBalanced()
        {

            int leftHeight = 0;
            int rightHeight = 0;
            if (this.LeftNode != null)
            {
                leftHeight = this.LeftNode.Height();
            }

            if(this.RightNode != null)
            {
                rightHeight = this.RightNode.Height();
            }

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;


            bool isLeftBalanced = LeftNode != null ? LeftNode.IsBalanced() :true ;
            bool isRightBalanced = RightNode != null ? RightNode.IsBalanced() : true ;

            return isLeftBalanced && isRightBalanced;
        }

        public string Seralize()
        {

            return serializeHelper(this);

        }

        private string serializeHelper(TreeNode root)
        {
           
            if (root == null)
                return "X";

            var leftSerialized = serializeHelper(root.LeftNode);
            var rightSerialized = serializeHelper(root.RightNode);

            return $"{root.Data} , {leftSerialized}, {rightSerialized}";
        }


        public TreeNode Deserialize(string serializedTree)
        {
            if (string.IsNullOrEmpty(serializedTree))
                return null;

            var queue = new Queue<string>();
            var charSerialized = serializedTree.Split(",");

            foreach (var item in charSerialized)
            {
                queue.Enqueue(item);
            }

            return deSerializeHelper(queue);
        }


        private TreeNode deSerializeHelper(Queue<string> queue)
        {

            if (queue.Count == 0)
                return null;

            var item = queue.Dequeue().Trim();
            

            if (item == "X")
                return null;


            var root = new TreeNode(Convert.ToInt32(item));

            root.LeftNode = deSerializeHelper(queue);
            root.RightNode = deSerializeHelper(queue);

            return root;

        }

        private bool hasPathSum(int sum)
        {
            return HasPathSumHelper(this, sum);
        }
        public bool HasPathSumHelper(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.Data == sum)
                return true;

            

            return (HasPathSumHelper(root.LeftNode, sum - root.Data.Value) || HasPathSumHelper(root.RightNode, sum - root.Data.Value));
        }
        
    }
}
