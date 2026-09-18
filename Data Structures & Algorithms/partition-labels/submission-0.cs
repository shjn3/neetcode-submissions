public class Solution {
    public List<int> PartitionLabels(string s) {
        List<int> res = new();
        int n = s.Length;
        int i =0;
        while(i<n){
            int start = i;
            int end =start+1;
            while(start<end){
                int cursor = end;
                while(cursor<n){
                    if(s[start]==s[cursor]){
                        end = cursor+1;
                    }
                    cursor++;
                }
                start++;
            }
            res.Add(end-i);
            i = end;
        }

        return res;
    }
}
