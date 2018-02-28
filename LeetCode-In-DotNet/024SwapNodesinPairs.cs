/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if(head==null||head.next==null)return head;
        ListNode current=head;
        ListNode newHeader=current.next;
        current.next=newHeader.next;
        newHeader.next=current;
        head=newHeader;
        ListNode first;
        ListNode second;
        while(current.next!=null&&current.next.next!=null)
        {
            first=current.next;
            second=first.next;
            first.next=second.next;
            current.next=second;
            second.next=first;
            current=first;
        }
        return newHeader;
        
    }
}