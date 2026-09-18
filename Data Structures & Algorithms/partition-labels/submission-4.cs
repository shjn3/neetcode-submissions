public class Solution {
    public List<int> PartitionLabels(string s) {
       int n = s.Length;
       Dictionary<char,int> lastIdx = new();
       for(int i =0;i<n;i++){
            lastIdx[s[i]]=i;
       }
    
       List<int> res = new();

        int cursor = 0;
        while(cursor<n){
            int maxId = lastIdx[s[cursor]];
            int t = cursor;
            while(t<=maxId){
                maxId = Math.Max(maxId,lastIdx[s[t]]);
                t++;
            }
            
            res.Add(maxId - cursor+1);
            cursor = maxId+1;
        }

        return res;
    }
}
