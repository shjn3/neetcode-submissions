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
    public bool CanAttendMeetings(List<Interval> intervals) {
        for(int i =0;i<intervals.Count;i++){

            Interval interval1 = intervals[i];
            for(int j=i+1;j<intervals.Count;j++){
                Interval interval2 = intervals[j];
                if(interval1.start-interval2.end>=0 || interval2.start-interval1.end>=0) continue;
                return false;
            }
        }

        return true;
    }
}
