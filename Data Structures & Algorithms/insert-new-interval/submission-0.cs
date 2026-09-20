public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> intervalList = new();
        int n =intervals.Length;
        bool isMerging = false;
        for(int i =0;i<n;i++){
            var interval = intervals[i];

            if(interval[1]<newInterval[0]){
                intervalList.Add(interval);
                continue;
            }

            if(interval[0]>newInterval[1]){
                if(!isMerging){
                    intervalList.Add(newInterval);
                    isMerging = true;
                }

                intervalList.Add(interval);
                continue;
            }
            newInterval[0] = Math.Min(interval[0],newInterval[0]);
            newInterval[1] = Math.Max(interval[1],newInterval[1]);
        }

        if(!isMerging){
            intervalList.Add(newInterval);
        }

        return intervalList.ToArray();
    }
}
