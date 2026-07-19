public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        PriorityQueue<int,int> _q=  new();
        Array.Sort(nums);
        int prevNum = nums[0];
        int count =1;
        for(int i=1;i<nums.Length;i++){
            if(nums[i]==prevNum){
                count++;
                continue;
            }
            _q.Enqueue(prevNum,count*-1);
            prevNum = nums[i];
            count=1;
        }
        _q.Enqueue(prevNum,count*-1);

        int[] res = new int[k];
        for(int i=0;i<k;i++){
            res[i] = _q.Dequeue();
        }


        return res;
    }
}
