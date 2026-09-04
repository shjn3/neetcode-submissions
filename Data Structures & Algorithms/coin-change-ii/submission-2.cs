public class Solution {
    Dictionary<(int,int),int> dp = new();
    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
       return DFS(coins,amount,0);
    }

    public int  DFS(int[] coins, int amount, int i){
        if(amount<0 || i>=coins.Length) return 0;
        if(amount==0) return 1;
        var k = (i,amount);
        if(dp.ContainsKey(k)) return dp[k];

        var left=  DFS(coins,amount,i+1);
        var deep = DFS(coins,amount-coins[i],i);


        dp[k] = left+deep;

        return dp[k];
    }
}
