public class Solution {
    public int MaxProfit(int[] prices) {
        int res = 0;
        int minPrice =prices[0];

        for(int i=1;i<prices.Length;i++){
            res = Math.Max(prices[i]-minPrice,res);
            minPrice = Math.Min(prices[i],minPrice);
        }
        return res;
    }
}
