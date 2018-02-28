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
    public int MinDepth(TreeNode root) {
        if(root==null) return 0;
        bool isFind=false;
        Queue<TreeNode> queue=new Queue<TreeNode>();
        queue.Enqueue(root);
        int count=0;
        while(queue.Count!=0)
        {
            queue=Travel(queue,ref isFind);
            count++;
            if(isFind)
                break;
        }
        return count;
    }
    private Queue<TreeNode> Travel(Queue<TreeNode> queue,ref bool isFind)
    {
        Queue<TreeNode> next=new Queue<TreeNode>();
        while(queue.Count!=0)
        {
            TreeNode node=queue.Dequeue();
            if(node.left==null&&node.right==null)
            {
                isFind=true;
                break;
            }
            if(node.left!=null)
                next.Enqueue(node.left);
            if(node.right!=null)
                next.Enqueue(node.right);
            
        }
        return next;
    }
}