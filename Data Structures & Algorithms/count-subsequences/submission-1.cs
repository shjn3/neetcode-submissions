public class Solution {
    int ans= 0;
    int[,] dp;
    public int NumDistinct(string s, string t) {
        dp = new int[s.Length+1,t.Length+1];
        for(int i =0;i<=s.Length;i++){
            for(int j =0;j<=t.Length;j++){
                dp[i,j]=-1;
            }
        }
        dfs(s,t,0,0);
        return dp[0,0];
    }

    public int dfs(string s, string t, int i1, int i2){
        if(i2>=t.Length ){
            return 1;
        }
        if(i1>=s.Length){
            return 0;
        }
        if(dp[i1,i2]!=-1) return dp[i1,i2];
        int a=0,b=0;
        if(s[i1]==t[i2]){
            a =   dfs(s,t,i1+1,i2+1);
        }
        b = dfs(s,t,i1+1,i2);       
        dp[i1,i2]=a+b;
        return dp[i1,i2];
    }
}
