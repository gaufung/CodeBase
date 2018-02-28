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
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums.Length==0)return null;
        TreeNode[] tree=new TreeNode[nums.Length];
        //init
        for(int i=0;i<nums.Length;i++)
        {
            tree[i]=new TreeNode(0);
        }
        int innerNode=nums.Length/2-1;
        for(int j=innerNode;j>=0;j--)
        {
            int leftIndex=2*j+1;
            int rightIndex=2*j+2;
            if(rightIndex<nums.Length)
                tree[j].right=tree[rightIndex];
            tree[j].left=tree[leftIndex];
        }
        InOrder(tree[0],nums);
        return tree[0];
    }
    private void InOrder(TreeNode root,int[] nums)
    {
        Stack<TreeNode> stack=new Stack<TreeNode>();
        GoAlongLeftBranch(stack,root);
        int index=0;
        while(stack.Count!=0)
        {
            TreeNode node=stack.Pop();
            node.val=nums[index];
            index++;
            GoAlongLeftBranch(stack,node.right);
        }
    }
    private void GoAlongLeftBranch(Stack<TreeNode> stack,TreeNode node)
    {
        while(node!=null)
        {
            stack.Push(node);
            node=node.left;
        }
    }
}