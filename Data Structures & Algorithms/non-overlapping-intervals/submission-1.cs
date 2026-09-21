public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals,(a,b)=>{
            if(a[0]==b[0]){
                return a[1].CompareTo(b[1]);
            }

            return a[0].CompareTo(b[0]);
        });

        int count =0;
        int i =0;
        int n = intervals.Length;

        while(i<n-1){
            var interval=intervals[i];
            int t =i;
            for(int j=i+1;j<n;j++){
                i=j;
                if(intervals[j][0]==interval[0]||intervals[j][0]<interval[1]){
                    if(intervals[j][1]<interval[1]){
                        interval = intervals[j];
                    }
                    count++;
                    continue;
                }
                if(intervals[j][0]>=interval[1]){
                    break;
                }
            }
        }


        return count;
    }
}
