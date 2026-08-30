public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n =nums.Length;
        int max = 0;
        int[] dp = new int[n];
        for(int i =0;i<n;i++){
            for(int j =i+1;j<n;j++){
                if(nums[j]>nums[i]){
                    dp[j] = Math.Max(dp[j],dp[i]+1);
                    max = Math.Max(dp[j],max);
                }
            }
        }

        return max+1;
    }
}
