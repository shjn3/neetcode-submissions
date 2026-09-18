public class Solution {
    public List<int> PartitionLabels(string s) {
       int n = s.Length;
       int[] max = new int[123];
       for(int i =0;i<s.Length;i++){
            max[s[i]] = Math.Max(max[s[i]],i);
       }

       List<int> res = new();

        int cursor = 0;
        while(cursor<n){
            int maxId = max[s[cursor]];
            int t = cursor;
            while(t<=maxId &&  maxId<n){
                maxId = Math.Max(maxId,max[s[t]]);
                t++;
            }
            res.Add(maxId - cursor+1);
            cursor = maxId+1;
        }

        return res;
    }
}
