public class Solution {
    public int LongestConsecutive(int[] nums) {
        int n =nums.Length;
        if(n<=1) return n;
       
        Array.Sort(nums);

        int max=0;
        int count=1;
        int previous = nums[0];
        for(int i =1;i<n;i++){
            int num = nums[i];
            if(num==previous) continue;
            if(num==previous+1){
                count++;
            }else{
                max = Math.Max(max,count);
                count =1;
            }

            previous = num;
        }


        return Math.Max(count,max);
    }
}
