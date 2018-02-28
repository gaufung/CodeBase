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
    public int MaxDepth(TreeNode root) {
        Stack<TreeNode> branch=new Stack<TreeNode>();
        Stack<int> depths=new Stack<int>();
        GoAlongWithLeftBranch(root,branch,depths,0);
        int maxDepths=0;
        while(branch.Count!=0)
        {
            TreeNode leaf=branch.Peek();
            int currentDepth=depths.Peek();
            maxDepths=Math.Max(maxDepths,currentDepth);
            branch.Pop();
            depths.Pop();
            GoAlongWithLeftBranch(leaf.right,branch,depths,currentDepth);
        }
        return maxDepths;
    }
    private void GoAlongWithLeftBranch(TreeNode node,Stack<TreeNode> branch,Stack<int> depths,int currentDepth)
    {
        //int currentDepth=depths.Peek();
        while(node!=null)
        {
            branch.Push(node);
            currentDepth++;
            depths.Push(currentDepth);
            node=node.left;
        }
    }
}