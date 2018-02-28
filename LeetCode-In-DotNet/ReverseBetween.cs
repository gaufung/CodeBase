/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        if(head==null) return head;
        ListNode cursor=head;
        ListNode first=Pos(cursor,m-1);
        cursor=first;
        int gap=n-m;
        ListNode second=Pos(cursor,gap);
        while(first!=second)
        {
            Swap(first,second);
            first=first.next;
            gap-=2;
            cursor=first;
            second=Pos(cursor,gap);
        }
        return head;
    }
    private void Swap(ListNode first,ListNode second)
    {
        int tmp=first.val;
        first.val=second.val;
        second.val=tmp;
    }
    private ListNode Pos(ListNode cursor,int counter)
    {
        while(counter>0&&cursor!=null)
        {
            cursor=cursor.next;
            counter--;
        }
        return cursor;
    }
}