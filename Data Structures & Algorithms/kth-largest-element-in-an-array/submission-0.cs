public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int,int> q =new();
        int j =0;
        foreach(var num in nums){
            q.Enqueue(j,-num);
            j++;
        }

        for(int i =0;i<k-1;i++){
            q.Dequeue();
        }

        return nums[q.Peek()];
    }
}
