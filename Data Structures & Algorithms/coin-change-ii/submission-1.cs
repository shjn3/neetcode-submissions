public class Solution {
    int res =0;
    Dictionary<(int,int),int> dp = new();
    public int Change(int amount, int[] coins) {
        if(amount==0) return 1;
        int total =0;
        for(int i =0;i<coins.Length;i++){
            total+=DFS(coins,amount,i,0);
        }

        // foreach(var kp in dp){
        //     Console.WriteLine("v: "+" "+kp.Key.Item1+" "+kp.Key.Item2+" "+kp.Value);
        // }
        return total;
    }

    public int DFS(int[] coins, int amount,int i,int current){
        if(i>=coins.Length||current>=amount) return 0;

        var key = (current,i);
        if(dp.ContainsKey(key)){
            return dp[key];
        }
        int total = 0;
        int nextCurrent= current + coins[i];
        if(nextCurrent == amount){
            dp[key] = 1;
        }else{
            for(int j =i;j<coins.Length;j++){
                total+=DFS(coins,amount,j,nextCurrent);
            }
            dp[key] = total;
        }
        return dp[key];
    }
}
