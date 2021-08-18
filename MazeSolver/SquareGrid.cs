using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class BinaryTree
    {
        public TreeNode root;


    }

    public class TreeNode
    {
        public int Key { get; set; }

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public MazeNode mazePoint { get; set; }

        public TreeNode(int item)
        {
            Key = item;
            Left = null;
            Right = null;
        }
    }
}
