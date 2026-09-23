public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        Array.Sort(intervals,(a,b)=>a[0].CompareTo(b[0]));
        int n = intervals.Length;
        int m =queries.Length;
        int minQ  =int.MaxValue;
        int maxQ = int.MinValue;
        for(int i =0;i<m;i++){
            minQ = Math.Min(minQ,queries[i]);
            maxQ = Math.Max(maxQ,queries[i]);
        }

        int qTableLength = maxQ-minQ+2;

        int[] qTable = new int[qTableLength];
        Array.Fill(qTable,int.MaxValue);

        for(int i =0;i<n;i++){
            var interval = intervals[i];
            if(interval[1]<minQ) continue;
            if(interval[0]>maxQ) continue;

            int l = interval[1]-interval[0]+1;
            for(int  j=Math.Max(0,interval[0]-minQ);j<=Math.Min(interval[1]-minQ,qTableLength-1);j++){

                qTable[j] = Math.Min(qTable[j],l);
            }
        }

        int[] output = new int[queries.Length];
        for(int i =0;i<m;i++){
            output[i] = qTable[queries[i]-minQ]==int.MaxValue?-1:qTable[queries[i]-minQ];
        }

        // int n = intervals.Length;

        // for(int i =0;i<m;i++){
        //     int query = queries[i];
        //     int min = int.MaxValue;
        //     for(int j=0;j<n;j++){
        //         var interval = intervals[j];
        //         if(interval[0]>query) break;
        //         if(interval[0]<=query && query<=interval[1]){
        //             min = Math.Min(min,interval[1]-interval[0]+1);
        //         }
        //     }

        //     output[i] = min==int.MaxValue? -1:min;
        // }

        return output;
    }
}
