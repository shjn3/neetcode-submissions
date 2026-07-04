public class Solution {
    public int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        int n =cost.Length;
        this.memo = new int[n+2];
        Array.Fill(this.memo,int.MaxValue);
        dfs(0,0,cost,n);
        int result = Math.Min(this.memo[^1],this.memo[^2]);

        Array.Fill(this.memo,int.MaxValue);
        dfs(1,0,cost,n);

        return Math.Min(result,Math.Min(this.memo[^1],this.memo[^2]));
    }

    public void dfs(int index,int currentCost, int[] cost, int n)
    {
        if(index>=n) 
        {
            this.memo[index]= Math.Min(currentCost,this.memo[index]);
            return;
        }
        int _c = currentCost+cost[index];
        if(this.memo[index]<_c) return;
        this.memo[index] = _c;
        dfs(index+1,_c,cost,n);
        dfs(index+2,_c,cost,n);
    }
}
