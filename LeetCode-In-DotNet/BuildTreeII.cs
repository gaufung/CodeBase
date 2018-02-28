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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if(inorder.Length==0)return null;
        return BuildTree(inorder,0,inorder.Length-1,postorder,0,postorder.Length-1);
    }
    private TreeNode BuildTree(int[] inorder,int inFrom,int inTo,int[] postorder,int postFrom,int postTo)
    {
        //the only one element
        if((inTo-inFrom)==0)
        {
            return new TreeNode(inorder[inFrom]);
        }
        //the element count greater than 1 
        else
        {
            int rootValue=postorder[postTo];
            TreeNode root=new TreeNode(rootValue);
            int index=Find(inorder,rootValue);
            //如果左孩子为空
            if(index==inFrom)
            {
                root.right=BuildTree(inorder,index+1,inTo,postorder,postFrom,postTo-1);
            }
            //如果右孩子为空
            else if(index==inTo)
            {
                root.left=BuildTree(inorder,inFrom,index-1,postorder,postFrom,postTo-1);
            }
            else
            {
                int leftCount=index-inFrom;
                int rightCount=inTo-index;
                root.right=BuildTree(inorder,index+1,inTo,postorder,postTo-rightCount,postTo-1);
                root.left=BuildTree(inorder,inFrom,index-1,postorder,postFrom,postFrom+leftCount-1);
            }
            return root;
            
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
}