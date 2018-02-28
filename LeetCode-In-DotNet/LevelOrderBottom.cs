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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        Queue<TreeNode> queue=new Queue<TreeNode>();
        queue.Enqueue(root);
        Stack<IList<int>> stack=new Stack<IList<int>>();
        while(queue.Count!=0)
        {
            IList<int> item=new List<int>();
            queue=Travel(queue,item);
            stack.Push(item);
        }
        while(stack.Count!=0)
        {
            res.Add(stack.Pop());
        }
        return res;
    }
    private Queue<TreeNode> Travel(Queue<TreeNode> queue,IList<int> item)
    {
        Queue<TreeNode> nextQueue=new Queue<TreeNode>();
        while(queue.Count!=0)
        {
            TreeNode node=queue.Dequeue();
            item.Add(node.val);
            if(node.left!=null)
                nextQueue.Enqueue(node.left);
            if(node.right!=null)
                nextQueue.Enqueue(node.right);
        }
        return nextQueue;
    }
}