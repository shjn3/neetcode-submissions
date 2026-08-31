public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length==1) return 0;
        int n =prices.Length;
        int[,] dp = new int[n,n];
        int res =0;

        for(int i =0;i<n;i++){
            int m =0;
            int price = prices[i];
            for(int k=0;k<i-1;k++){
                for(int l=0;l<i-1;l++){
                    m = Math.Max(m,dp[k,l]);
                }
            }
            dp[i,i]=m;

            for(int j=i+1;j<n;j++){
                dp[i,j]= m+Math.Max(0,prices[j]-price);
                res = Math.Max(res,dp[i,j]);
            }
        }
        
        return res;
    }
}
