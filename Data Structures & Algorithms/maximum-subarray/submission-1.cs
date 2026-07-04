public class Solution {
    public int MaxSubArray(int[] nums) {
        if(nums.Length==1) return nums[0];
        int max =nums[0];
        int sum =nums[0];
        for(int i=1;i<nums.Length;i++){
            sum = Math.Max(nums[i],nums[i]+sum);
            max =Math.Max(max,sum);
        }

        return max;
    }
}
