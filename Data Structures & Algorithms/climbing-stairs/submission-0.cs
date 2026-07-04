public class Solution {
    public int[] memo;
    public int ClimbStairs(int n) {     
        this.memo= new int[n];
        return  this.dfs(0,n);
    }

    public int dfs( int current,int n){
        if(current>n) return 0;
        if(current==n)  return 1;
        if(memo[current]!=0) return memo[current];
        memo[current] = this.dfs(current+1,n)+this.dfs(current+2,n);
        return memo[current];
    }
}
