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
           dp[k]= MinDistance(word1.Substring(i1),word2.Substring(i1));
        }else{
            string nextWord2 = word2.Substring(1);
            string nextWord1 = word1.Substring(1);

            int r1 = MinDistance(nextWord1,word2);
            int r2 = MinDistance(nextWord1,nextWord2);
            int r3 = MinDistance(word1,nextWord2);
            dp[k] = Math.Min(r1,Math.Min(r2,r3)) + 1;
        }

        return dp[k];
    }
}
