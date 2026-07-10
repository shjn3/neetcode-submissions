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
    public bool HasCycle(ListNode head) {
        if(head==null ) return false;
        ListNode slow =head;
        ListNode fast =head.next;
        while(fast!=null&& fast.next!=null){
            if(slow==fast) return true;
            slow = slow.next;
            fast = fast.next.next;
        }   

        return false;
    }
}
