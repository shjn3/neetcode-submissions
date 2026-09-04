public class Solution {
       public int LongestCommonSubsequence(string text1, string text2) {
        int m=text1.Length;
        int n = text2.Length;
        int [,] dp = new int[m+1,n+1];
        
        for(int i =m-1;i>=0;i--){
            for(int  j=n-1;j>=0;j--){
                if(text1[i]==text2[j]){
                    dp[i,j] = Math.Max(dp[i+1,j+1]+1,dp[i,j]);
                }else{
                    dp[i,j] = Math.Max(dp[i+1,j],Math.Max(dp[i,j+1],dp[i,j]));
                }
            }
        }

        return dp[0,0];
    }
}
