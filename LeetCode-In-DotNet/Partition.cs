/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        if(head==null||head.next==null) return head;
        ListNode first=head;
        while(first!=null)
        {
            ListNode second=first.next;
            if(first.val>=x)
            {
                while(second!=null)
                {
                    if(second.val<x)
                        break;
                    else{
                      second=second.next;  
                    }
                    
                }
                if(second!=null)
                {
                    Swap(first,second);
                    Iterate(first.next,second);
                }
                else{
                    break;
                }
            }
            first=first.next;  
            
        }
        return head;
    }
    private void Iterate(ListNode first,ListNode second)
    {
        while(first!=second)
        {
            Swap(first,second);
            first=first.next;
        }
    }
    private void Swap(ListNode node1,ListNode node2)
    {
        int temp=node1.val;
        node1.val=node2.val;
        node2.val=temp;
    }
}