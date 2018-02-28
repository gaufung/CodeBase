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
    public bool IsSymmetric(TreeNode root) {
        if(root==null) return true;
        return IsSame(root.left,root.right);
    }
    private bool IsSame(TreeNode p,TreeNode q)
    {
        if(p==null&&q==null) return true;
        if(p==null&&q!=null) return false;
        if(p!=null&&q==null) return false;
        if(p.val!=q.val) 
            return false;
        else
        {
            bool res=true;
            res&=IsSame(p.left,q.right);
            res&=IsSame(p.right,q.left);
            return res;
        }
        
    }
}