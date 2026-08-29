public class Solution {
    public int CountSubstrings(string s) {
        int n =s.Length;
        bool[,] dp = new bool[n,n];
        for(int i =0;i<n;i++){
            dp[i,i] = true;
        }
        int count =n;
        for(int  i=n-1;i>=0;i-- ){
            for(int j=i+1;j<n;j++){
                if(s[i]==s[j] && (j-i<=2 || dp[i+1,j-1])){
                    count++;
                    dp[i,j] =true;
                }
            }
        }

        return count;
    }
}
