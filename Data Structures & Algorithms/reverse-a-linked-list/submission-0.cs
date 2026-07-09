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
    public ListNode ReverseList(ListNode head) {
        if(head==null||head.next==null) return head;
        ListNode holdNext= head.next;
        head.next = null;
        while(holdNext.next!=null){
            ListNode temp =holdNext.next;
            holdNext.next = head;
            head = holdNext;
            holdNext = temp;
        }
        Console.WriteLine("Next: "+holdNext.val);
        holdNext.next = head;
        return holdNext;
    }
}
