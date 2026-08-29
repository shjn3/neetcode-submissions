public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount ==0) return 0;
        int[] dp = new int[amount+1];
        Array.Fill(dp,int.MaxValue);
        dp[0] = 0;

        foreach(var c in coins){

            for(int  i= c;i<=amount;i++){
                if(dp[i-c]==int.MaxValue) continue;
                dp[i] = Math.Min(1+dp[i-c],dp[i]);
            }
        }

        return dp[^1]==int.MaxValue?-1:dp[^1];
    }
}
