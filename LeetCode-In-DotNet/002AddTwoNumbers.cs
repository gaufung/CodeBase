/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var add1=Convert(l1);
        var add2=Convert(l2);
        var res=add1+add2;
        return Convert(res);
    }
    private long Convert(ListNode list)
    {
          long res=list.val;
          int power=1;
          ListNode tailer=list.next;
          while (tailer!=null)
          {
              res+=tailer.val*(long)Math.Pow(10,power);
              power++;
              tailer=tailer.next;
          }
          return res;
    }
    private ListNode Convert(long val)
    {
        long power=10;
        ListNode node=new ListNode((int)(val%power));
        val/=power;
        ListNode header=node;
        while(val>0)
        {
           while(node.next!=null)
           {
               node=node.next;
           }
           node.next=new ListNode((int)(val%power));
           val/=power;
        }
        return header;
    }
}