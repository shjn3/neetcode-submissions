public class Solution {
    Dictionary<(int,int),int> dp = new();
    public int FindTargetSumWays(int[] nums, int target) {
   
       return DP(nums,target,1,nums[0])+DP(nums,target,1,-nums[0]);
    }

    public int DP(int[] nums,int target, int i, int current ){
        if(i==nums.Length){
            if(current==target) return 1;
            return 0;
        }

        var key = (current,i);
        if(!dp.ContainsKey(key)) {
            dp[key]= DP(nums,target,i+1,current+nums[i]) + DP(nums,target,i+1,current-nums[i]);
        }

        return dp[key];
    }
}
