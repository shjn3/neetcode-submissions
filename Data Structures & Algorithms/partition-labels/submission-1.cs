public class Solution {
    public List<int> PartitionLabels(string s) {
       int n = s.Length;
       int[] min = new int[26];
       Array.Fill(min,n-1);
       int[] max = new int[26];

       for(int i =0;i<s.Length;i++){
            int id = s[i]-97;
            min[id] = Math.Min(min[id],i);
            max[id] = Math.Max(max[id],i);
       }

    //    for(int i =0;i<min.Length;i++){
    //        Console.WriteLine(min[i]+" "+max[i]);
    //    }

       List<int> res = new();

        int cursor = 0;
        while(cursor<n){
            int id = s[cursor]-97;
            int minId = min[id];
            int maxId = max[id];
            int t = cursor;

            while(t<=maxId &&  maxId<n){
                int tempId = s[t]-97;
                maxId = Math.Max(maxId,max[tempId]);
                t++;
            }
            res.Add(maxId - cursor+1);
            // Console.WriteLine("Max: "+maxId);
            // if(maxId==cursor){
            //     cursor++;
            // }else{
            //    cursor = maxId+1;
            // }
            cursor = maxId+1;
        }

        return res;
    }
}
