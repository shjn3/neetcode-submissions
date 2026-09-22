/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        if(intervals.Count==0) return 0;

        List<int[]> time = new();
        for(int i =0;i<intervals.Count;i++){
            time.Add(new int[]{
                intervals[i].start,1
            });
           time.Add(new int[]{
                intervals[i].end,-1
            });
        }

        time.Sort((a,b)=>a[0]==b[0]?a[1].CompareTo(b[1]):a[0].CompareTo(b[0]));

        int count =0;
        int res = 0;
        foreach(var t in time){
            count+=t[1];
            res = Math.Max(res,count);
        }

        return res;
    }
}
