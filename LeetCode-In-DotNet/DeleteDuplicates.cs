/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return head;
        ListNode first=head;
        ListNode last=head.next;
        while(last!=null)
        {
            if(first.val!=last.val)
            {
                first.next=last;
                last=last.next;
                first=first.next;
            }
            else
            {
                last=last.next;
                first.next=last;
            }
        }
        return head;
    }
}