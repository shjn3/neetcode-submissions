public class Solution {
    public string LongestPalindrome(string s) {
       int n = s.Length;
        bool[,] dp = new bool[n, n];
        
        int start = 0, maxLen = 1;

        // All substrings of length 1 are palindromes
        for (int i = 0; i < n; ++i)
            dp[i, i] = true;

        // Check for sub-string of length 2
        for (int i = 0; i < n - 1; ++i) {
            if (s[i] == s[i + 1]) {
                dp[i, i + 1] = true;
                if (maxLen < 2) {
                    start = i;
                    maxLen = 2;
                }
            }
        }

        // Check for lengths greater than 2
        for (int k = 3; k <= n; ++k) {
            for (int i = 0; i < n - k + 1; ++i) {
                int j = i + k - 1;

                if (dp[i + 1, j - 1] && s[i] == s[j]) {
                    dp[i, j] = true;

                    if (k > maxLen) {
                        start = i;
                        maxLen = k;
                    }
                }
            }
        }

        return s.Substring(start, maxLen);
    }


    bool IsPalindromic(string s){
        int left = 0;
        int right = s.Length-1;
        while(left<=right){
            if(s[left]==s[right]){
                left++;
                right--;
            }
            return false;
        }
        return true;
    }
}
