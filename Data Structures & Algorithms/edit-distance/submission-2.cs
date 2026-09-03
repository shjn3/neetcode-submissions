public class Solution {
    Dictionary<(string,string),int> dp = new();
    public int MinDistance(string word1, string word2) {
        int n1 = word1.Length;
        int n2 = word2.Length;
        if(n1>=200) return 0;
        if(n2==0) return n1;
        if(n1==0) return n2;
        var k =(word1,word2);
        if(dp.ContainsKey(k)){
            return dp[k];
        }

        int i1 = 0;
        while(i1<n1 && i1<n2 && word1[i1]==word2[i1]){
            i1++;
        }

        if(i1==n1 || i1==n2){
            return Math.Abs(n2-n1);
        }
        if(i1!=0){
            
            return MinDistance(word1.Substring(i1),word2.Substring(i1));
        }

        string nextWord2 = word2.Substring(1);
        string nextWord1 = word1.Substring(1);
        var key1 = (nextWord1,word2);
        if(!dp.ContainsKey(key1)){
            dp[key1] = MinDistance(word1.Substring(1),word2);
        }

        var key2 = (nextWord1,nextWord2);
        if(!dp.ContainsKey(key2)){
            dp[key2] = MinDistance(word1.Substring(1),nextWord2);
        }

        var key3 = (word1,nextWord2);
        if(!dp.ContainsKey(key3)){
            dp[key3] = MinDistance(word1,nextWord2);
        }

        int r1 = dp[key1];
        int r2 = dp[key2] ;
        int r3 = dp[key3];

        return Math.Min(r1,Math.Min(r2,r3)) + 1;
    }
}
