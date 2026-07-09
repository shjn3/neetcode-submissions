/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        if(head.next==null) return;
        ListNode prev = null;
        ListNode clone = new ListNode(head.val,prev);
        
        ListNode current = head;
        int totalCount =1;
        while(current.next!=null){
            clone.next = prev;
            prev = clone;
            clone = new ListNode(current.next.val,null);
            current=current.next;
            totalCount++;
        }
        clone.next = prev;

        ListNode cursor = head;
        ListNode cursor2 = clone;
        int count= (totalCount-1)/2;

        while(cursor!=null && cursor2!=null && count>0){
            ListNode _next1 = cursor.next;
            ListNode _next2 = cursor2.next;

            cursor.next = cursor2;
            cursor2.next = _next1;
            cursor= _next1;
            cursor2= _next2; 
            count--;
        }
        if(totalCount%2==0){
            cursor.next=cursor2;
            cursor2.next = null;
        }
        else{
            cursor.next = null;
        }

        return;
     }
}
