public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals,(a,b)=>a[0].CompareTo(b[0]));

        int count =0;
        int prevEnd = intervals[0][1];
        int n = intervals.Length;
        for(int i=1;i<n;i++){
            int start = intervals[i][0];
            int end = intervals[i][1];

            if(prevEnd<=start){
                prevEnd =end;
            }else{
                count++;
                prevEnd = Math.Min(end,prevEnd);
            }
        }

     


        return count;
    }
}
