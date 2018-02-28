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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length==0) return null;
        if(preorder.Length==1&&inorder.Length==1)
        {
            return new TreeNode(preorder[0]);
        }
        else
        {
            int rootValue=preorder[0];
            TreeNode node=new TreeNode(rootValue);
            int index=Find(inorder,rootValue);
            //如果左孩子为空
            if(index==0)
            {
                node.right=BuildTree(CopyFrom(preorder,1,preorder.Length-1),CopyFrom(inorder,1,inorder.Length-1));
            }
            //如果右孩子为空
            if(index==inorder.Length-1)
            {
                node.left=BuildTree(CopyFrom(preorder,1,preorder.Length-1),CopyFrom(inorder,0,index-1));
            }
            else
            {
                node.left=BuildTree(CopyFrom(preorder,1,index),CopyFrom(inorder,0,index-1));
                node.right=BuildTree(CopyFrom(preorder,index+1,preorder.Length-1),CopyFrom(inorder,index+1,inorder.Length-1));
            }
            return node;
        }
    }
    private int Find(int[] array,int value)
    {
        int i=array.Length-1;
        for(;i>=0;i--)
        {
            if(array[i]==value)
                break;
        }
        return i;
    }
    private int[] CopyFrom(int[] array,int from,int to)
    {
        int[] res=new int[to-from+1];
        for(int i=from;i<=to;i++)
        {
            res[i-from]=array[i];
        }
        return res;
    }
}