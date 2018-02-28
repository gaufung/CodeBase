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
    public bool IsBalanced(TreeNode root) {
        if(root==null) return true;
        int leftHeight=GetHeight(root.left);
        int rightHeight=GetHeight(root.right);
        if(Math.Abs(leftHeight-rightHeight)>1)
            return false;
        return IsBalanced(root.left)&&IsBalanced(root.right);
    }
    
    private int GetHeight(TreeNode node)
    {
        if(node==null) 
            return 0;
        else
            return Math.Max(GetHeight(node.left),GetHeight(node.right))+1;
    }
}