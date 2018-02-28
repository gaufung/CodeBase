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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> res=new List<int>();
        if(root==null) return res;
        Stack<TreeNode> stack=new Stack<TreeNode>();
        GoAlongLeftBranch(root,stack);
        while(stack.Count!=0)
        {
            TreeNode node=stack.Peek();
            res.Add(node.val);
            stack.Pop();
            GoAlongLeftBranch(node.right,stack);
        }
        return res;
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