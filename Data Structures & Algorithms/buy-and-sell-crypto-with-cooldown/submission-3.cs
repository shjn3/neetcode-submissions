public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length==1) return 0;

        return  recursive(prices,0,true);
    }
    private Dictionary<(int,bool),int> dp = new();

    public int recursive(int[] prices,int i, bool buying){
        if(i>=prices.Length){
            return 0;
        }

        var key = (i,buying);
        if(dp.ContainsKey(key)){
            return dp[key];
        }

        int coolDown = recursive(prices,i+1,buying);
        dp.TryAdd(key,coolDown);
        
        if(buying){
            int buy = recursive(prices,i+1,false)-prices[i];
            dp[key] = Math.Max(buy,dp[key]);
        }else{
            int sell = recursive(prices,i+2,true)+prices[i];
            dp[key] = Math.Max(sell,dp[key]);
        }

        return dp[key];
    }
}
