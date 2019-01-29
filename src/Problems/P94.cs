using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-inorder-traversal/
    /// </summary>
    public class P94
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            return InorderTraversal(root, new List<int>());
        }

        public IList<int> InorderTraversal(TreeNode root, IList<int> list)
        {
            if (root == null)
            {
                return list;
            }
            InorderTraversal(root.left, list);
            list.Add(root.val);
            InorderTraversal(root.right, list);
            return list;
        }
    }
}
