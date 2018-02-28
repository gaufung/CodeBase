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
    public void Flatten(TreeNode root) {
        if(root==null) return;
        Swap(root);
    }
    private TreeNode Swap(TreeNode node)
    {
        if(node.left==null&&node.right==null)
            return node;
        if(node.left==null&&node.right!=null)
        {
            node.right=Swap(node.right);
        }
        else if(node.left!=null&&node.right==null)
        {
            node.right=Swap(node.left);
            node.left=null;
        }
        else if(node.left!=null&&node.right!=null)
        {
            TreeNode leftNode=node.left;
            TreeNode rightNode=node.right;
            node.right=Swap(leftNode);
            node.left=null;
            TreeNode cur=node;
            while(cur.right!=null)
            {
                cur=cur.right;
            }
            cur.right=Swap(rightNode);
        }
        return node;
    }
}