public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        int n= s.Length;
        HashSet<string> _set = new();
        int minSize = int.MaxValue;
        int maxSize = int.MinValue;

        for(int k =0;k<wordDict.Count;k++){
            _set.Add(wordDict[k]);
            int l = wordDict[k].Length;
            minSize = Math.Min(minSize, l);
            maxSize = Math.Max(maxSize,l);
        }

        bool[] dp = new bool[n];
        int i=0;
        while(i<n){
            if(i>0&&!dp[i-1]){
                i++;
                continue;
            }

            for(int j =i+minSize;j<=i+maxSize && j<=n;j++){
                if(_set.Contains(s.Substring(i,j-i))){
                    dp[j-1] = true;
                }
            }

            i+=minSize;
        }


        return dp[^1];
    }
}
