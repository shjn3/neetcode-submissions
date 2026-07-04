public class Solution {
    public int ClimbStairs(int n) { 
        int dpLength = n+1;    
        int[] dp = new int[dpLength];
        dp[0]=1;

        for(int i=0;i<=n;i++){
            if(i+1<dpLength){
                dp[i+1] += dp[i];
            }

            if(i+2<dpLength){
                 dp[i+2] += dp[i];
            }
        }


        return dp[n];
    }
}
