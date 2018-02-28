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
    public bool IsValidBST(TreeNode root) {
        if(root==null) return true;
        Stack<TreeNode> stack=new Stack<TreeNode>();
        GoAlongLeftBranch(root,stack);
        int comparer=stack.Peek().val;
        bool isFirst=true;
        while(stack.Count!=0)
        {
            var current=stack.Peek().val;
            if(!isFirst){
               if(current<=comparer) return false; 
            }
            comparer=current;
            var node=stack.Peek().right;
            stack.Pop();
            isFirst=false;
            GoAlongLeftBranch(node,stack);
        }
        return true;
    }
    private void GoAlongLeftBranch(TreeNode node,Stack<TreeNode> stack)
    {
        while(node!=null)
        {
            stack.Push(node);
            node=node.left;
        }
    }
}