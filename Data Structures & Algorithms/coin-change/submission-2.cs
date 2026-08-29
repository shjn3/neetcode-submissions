public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount ==0) return 0;
        int[] dp = new int[amount+1];
        HashSet<int> coinSet = new();

        for(int i =0;i<coins.Length;i++){
            coinSet.Add(coins[i]);
            if(coins[i]==amount){
                return 1;
            }
        }
        Array.Fill(dp,int.MaxValue);
        dp[0] = 0;
        for(int i =1;i<=amount;i++){
            if(coinSet.Contains(i)){
                dp[i] = 1;
            }else{
                for(int j=i-1;j>=i-j;j--){
                    int num1 = dp[j];
                    if(num1==int.MaxValue) continue;
                    int factor1 = i/j;
                    int remainder = i%j;
                    if(remainder!=0  && dp[remainder]==int.MaxValue) continue;

                    dp[i] = Math.Min(dp[j]*factor1+dp[remainder],dp[i]);
                }
            }
        }


        return dp[^1]==int.MaxValue?-1:dp[^1];
    }
}
