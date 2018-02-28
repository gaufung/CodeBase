/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
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
    public TreeNode SortedListToBST(ListNode head) {
        int length=Count(head);
        if(length==0)return null;
        TreeNode[] tree=new TreeNode[length];
        //init
        for(int i=0;i<length;i++)
        {
            tree[i]=new TreeNode(0);
        }
        int innerNode=length/2-1;
        for(int j=innerNode;j>=0;j--)
        {
            int leftIndex=2*j+1;
            int rightIndex=2*j+2;
            if(rightIndex<length)
                tree[j].right=tree[rightIndex];
            tree[j].left=tree[leftIndex];
        }
        InOrder(tree[0],head);
        return tree[0];
    }
    private void InOrder(TreeNode root,ListNode head)
    {
        Stack<TreeNode> stack=new Stack<TreeNode>();
        GoAlongLeftBranch(stack,root);
        while(stack.Count!=0)
        {
            TreeNode node=stack.Pop();
            node.val=head.val;
            head=head.next;
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
    private int Count(ListNode node)
    {
        ListNode current=node;
        int count=0;
        while(current!=null)
        {
            count++;
            current=current.next;
        }
        return count;
    }
}