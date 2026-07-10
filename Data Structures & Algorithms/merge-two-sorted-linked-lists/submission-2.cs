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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1==null) return list2;
        if(list2==null) return list1;
        ListNode larger = list1.val>list2.val?list1:list2;
        ListNode smaller = list1.val>list2.val?list2:list1;
        ListNode res = smaller;

        while(larger!=null && smaller!=null){
            ListNode smallerNext= smaller.next;
            if(smallerNext!=null && smallerNext.val<larger.val){
                smaller = smaller.next;
                continue;
            }
            smaller.next= larger;
            
            if(smallerNext==null){
              break;
            }


            while(larger.next!=null && larger.next.val<smallerNext.val){
                larger = larger.next;
            }

            ListNode largerNext = larger.next;
            larger.next= smallerNext;
            if(largerNext ==null){
                break;
            }
            
            smaller= smallerNext;
            larger = largerNext;
        }



        return res;
    }
}