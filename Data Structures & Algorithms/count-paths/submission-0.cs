public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] dp = new int[m,n];
        dp[0,0]=1;

        for(int i =0;i<m;i++){
            int d = i+1;
            for(int j=0;j<n;j++){
                int r = j+1;
                if(r<n){
                    dp[i,r]+=dp[i,j];
                }

                if(d<m){
                    dp[d,j]+=dp[i,j];
                }
            }
        }

        return dp[m-1,n-1];
    }
}
