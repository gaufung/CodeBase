/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if(head==null) return head;
        ListNode cursor=head;
        int totalCount=1;
        while(cursor.next!=null)
        {
            totalCount++;
            cursor=cursor.next;
        }
        k=k%totalCount;
        if(k>0)
        {
            //连接成一个圈
            cursor.next=head;
            int toMove=totalCount-k;
            ListNode newCur=head;
            while(toMove>1)
            {
                newCur=newCur.next;
                toMove--;
            }
            head=newCur.next;
            newCur.next=null;
            
        }
        return head;
        
    }
}