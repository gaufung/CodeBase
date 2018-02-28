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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> res=new List<IList<int>>();
        if(root==null) return res;
        IList<TreeNode> nodes=new List<TreeNode>();
        nodes.Add(root);
        while(nodes.Count!=0)
        {
            nodes=Travel(nodes,res);
        }
        return res;
        
    }
    private IList<TreeNode> Travel(IList<TreeNode> nodes,IList<IList<int>> res)
    {
        IList<int> item=new List<int>();
        IList<TreeNode> level=new List<TreeNode>();
        foreach(var node in nodes)
        {
            item.Add(node.val);
            if(node.left!=null)
                level.Add(node.left);
            if(node.right!=null)
                level.Add(node.right);
        }
        res.Add(item);
        return level;
    }
}