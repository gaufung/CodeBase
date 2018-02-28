/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        if(root.left==null&&root.right==null&&root.val==sum)
        {
            IList<int> item=new List<int>(){root.val};
            return new List<IList<int>>(){item};
        }
        IList<IList<int>> leftPath=new List<IList<int>>();
        IList<IList<int>> rightPath=new List<IList<int>>();
        if(root.left!=null)
        {
            leftPath=PathSum(root.left,sum-root.val);
            foreach(var item in leftPath)
            {
                item.Insert(0,root.val);
            }
        }
        if(root.right!=null)
        {
            rightPath=PathSum(root.right,sum-root.val);
            foreach(var item in rightPath)
            {
                item.Insert(0,root.val);
            }
        }
     
        foreach(var item in leftPath)
            res.Add(item);
        foreach(var item in rightPath)
            res.Add(item);
        return res;
        
        
    }
}