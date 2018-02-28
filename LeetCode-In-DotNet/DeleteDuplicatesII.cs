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
        if(head==null||head.next==null) return head;
       ListNode preHead=new ListNode(-1);
       preHead.next=head;
       ListNode first=preHead;
       ListNode second=head;
       bool isDuplicate=false;
       while(second.next!=null)
       {
           if(first.next.val==second.next.val)
           {
               second=second.next;
               isDuplicate=true;
           }
           else{
               if(isDuplicate)
               {
                   first.next=second.next;
                   second=second.next;
               }
               else{
                    first=first.next;
                    second=second.next;
               }
                isDuplicate=false;
           }
       } 
       if(isDuplicate)
       {
           first.next=null;
       }
       return preHead.next;
    }
}