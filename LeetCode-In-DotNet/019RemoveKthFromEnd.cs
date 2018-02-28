/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        //because the n will always be valid,so we donnot consider 
        //the invaild index;
        ListNode[] storedPointers=new ListNode[n];
        storedPointers[0]=head;
        for(int i=1;i<n;i++)
        {
            storedPointers[i]=storedPointers[i-1].next;
        }
        ListNode hook=null;
        while(storedPointers[n-1].next!=null)
        {
            hook=storedPointers[0];
            for(int i=0;i<n;i++)
            {
                storedPointers[i]=storedPointers[i].next;
            }
        }
        if(hook==null)
        {
            return storedPointers[0].next;
        }
        else
        {
            hook.next=storedPointers[0].next;
            return head;
        }       
    }
}