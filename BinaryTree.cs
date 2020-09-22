using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree
    {

        public TreeNode Root { get; set; }

        public BinaryTree()
        {
            this.Root = null;

        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                //Add Root
                Root = new TreeNode(value);
            }
            else
            {
                Root.Insert(value);
            }
        }

        public void InOrderTraversal()
        {
            if (Root != null)
            {
                Root.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            if (Root != null)
            {
                Root.PreOrderTraversal();
            }
        }

        public TreeNode Find(int val)
        {
            if (Root.Data == val)
                return Root;

            return Root.Find(val);
        }

        public TreeNode FindRecursive(int val)
        {
            if (Root.Data == val)
                return Root;

            return Root.FindRecursive(val);
        }

        public int? Min()
        {
            if (Root == null)
                return null;

            return Root.MinRecursive();
        }

        public int? Max()
        {
            if (Root == null)
                return null;

            return Root.MaxRecursive();
        }


        public int Height()
        {
            if (Root == null)
                return 0;

            return Root.Height();
        }  

        public int? NumberOfLeafs()
        {
            return Root.NumberOfLeafs();
        }

        public string Serialize()
        {
            return Root.Seralize();
        }

        public TreeNode Deserialize(string serializedTree)
        {
            return Root.Deserialize(serializedTree);
        }

        public bool hasPathSum(int sum)
        {
            return Root.HasPathSumHelper(Root, 192);
        }
    }
}
