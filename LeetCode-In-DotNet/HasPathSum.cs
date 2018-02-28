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
    public bool HasPathSum(TreeNode root, int sum) {
        if(root==null) return false;
        if(root.left==null&&root.right==null&&root.val==sum)
            return true;
        if(root.left==null&&root.right==null&&root.val!=sum)
            return false;
        bool leftSum=false;
        bool rightSum=false;
        if(root.left!=null)
            leftSum|=HasPathSum(root.left,sum-root.val);
        if(root.right!=null)
            rightSum|=HasPathSum(root.right,sum-root.val);
        return leftSum||rightSum ;
    }
}