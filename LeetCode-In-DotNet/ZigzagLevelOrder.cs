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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        Stack<TreeNode> stack=new Stack<TreeNode>();
        stack.Push(root);
        bool zig=true;
        while(stack.Count!=0)
        {
            IList<int> item=new List<int>();
            stack=Travel(stack,zig,item);
            res.Add(item);
            zig=!zig;
        }
        return res;
    }
    private Stack<TreeNode> Travel(Stack<TreeNode> root,bool direction,IList<int> item)
    {
        Stack<TreeNode> stack=new Stack<TreeNode>();
        while(root.Count!=0)
        {
            var node=root.Peek();
            item.Add(node.val);
            if(direction)
            {
                if(node.left!=null)
                    stack.Push(node.left);
                if(node.right!=null)
                    stack.Push(node.right);
            }
            else
            {
                if(node.right!=null)
                    stack.Push(node.right);
                if(node.left!=null)
                    stack.Push(node.left);
            }
            root.Pop();
        }
        return stack;
    }
}