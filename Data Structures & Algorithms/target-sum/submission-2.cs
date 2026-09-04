public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
     int sum = nums.Sum();
     
     if(Math.Abs(target)>sum) return 0;
     if((sum+target)%2!=0) return 0;

     int subsetTarget = (sum+target)/2;
     int n = nums.Length;
     int[,] dp = new int[n+1,subsetTarget+1];

    // for(int i =0;i<=n;i++){
    //     dp[i,0] = 1;
    // }
    dp[0,0]=1;

    for(int i=1;i<=n;i++){
        for(int j =0;j<=subsetTarget;j++){
            if(nums[i-1]<=j){
                dp[i,j] = dp[i-1,j-nums[i-1]] + dp[i-1,j];
            }else{
                dp[i,j] = dp[i-1,j];
            }
        }
    }

    return dp[n,subsetTarget];
      
    }
}
