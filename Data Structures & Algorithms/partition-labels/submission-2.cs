public class Solution {
    public List<int> PartitionLabels(string s) {
       int n = s.Length;
       int[] max = new int[26];
       for(int i =0;i<s.Length;i++){
            int id = s[i]-97;
            max[id] = Math.Max(max[id],i);
       }

       List<int> res = new();

        int cursor = 0;
        while(cursor<n){
            int maxId = max[s[cursor]-97];
            int t = cursor;
            while(t<=maxId &&  maxId<n){
                maxId = Math.Max(maxId,max[s[t]-97]);
                t++;
            }
            res.Add(maxId - cursor+1);
            cursor = maxId+1;
        }

        return res;
    }
}
