public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> res = new();

        Array.Sort(intervals,(a,b)=>a[0].CompareTo(b[0]));
        res.Add(intervals[0]);
        int n = intervals.Length;
        for(int i =1;i <n;i++){
            var previous = res[^1];
            var interval = intervals[i];
            if(interval[0]>previous[1]){
                res.Add(interval);
            }else{
                previous[0] = Math.Min(previous[0],interval[0]);
                previous[1] = Math.Max(previous[1],interval[1]);
            }
        }

        return res.ToArray();
    }
}
