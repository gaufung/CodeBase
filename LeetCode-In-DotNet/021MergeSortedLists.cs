/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        //valid check
        if(l1==null) return l2;
        if(l2==null) return l1;
        
        //merge sort
        ListNode first=l1;
        ListNode second=l2;
        ListNode firstTemp=first;
        while(first!=null&&second!=null)
        {
            //如果第一个结果
            if(first.val<=second.val)
            {
                firstTemp=first;
                first=first.next;
                continue;
            }
            else
            {
                ListNode temp=second.next;
                second.next=first.next;
                first.next=second;
                //swap the value 
                {
                    int tempVal=first.val;
                    first.val=second.val;
                    second.val=tempVal;
                }
                //change the pointer
                first=first.next;
                second=temp;
            }
        }
        if(first==null)
        {
            firstTemp.next=second;
        }
        return l1;
        
    }
}