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
    public int SumNumbers(TreeNode root) {
        if(root==null) return 0;
        return Sum(root,0);
        
    }
    private int Sum(TreeNode node,int parent)
    {
        if(node.left==null&&node.right==null)
            return parent*10+node.val;
        if(node.left==null&&node.right!=null)
            return Sum(node.right,parent*10+node.val);
        if(node.left!=null&&node.right==null)
            return Sum(node.left,parent*10+node.val);
        else
            return Sum(node.left,parent*10+node.val)+Sum(node.right,parent*10+node.val);
    }
}