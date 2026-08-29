public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n,n];
        for(int i =0;i<n;i++){
            dp[i,i]=true;
        }

        for(int i =n-1;i>=0;i--){
            for(int j =i+1;j<n;j++){
                if((dp[i+1,j-1] || j-i<=2) &&s[i]==s[j]){
                    dp[i,j]=true;
                }
            }
        }
        int start =0;
        int l = 1;
        for(int i =0;i<n;i++){
            for(int j =i+1;j<n;j++){
                if(dp[i,j]){
                    int count =j-i+1;
                    if(count>l){
                        start = i;
                        l=count;
                    }
                }
            }
        }  
 
        return s.Substring(start,l);
    }
}
