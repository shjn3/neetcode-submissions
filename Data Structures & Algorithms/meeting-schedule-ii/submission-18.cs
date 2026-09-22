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
        intervals.Sort((a,b)=>a.start.CompareTo(b.start));
        int n =intervals.Count;

       PriorityQueue<int,int> q =new();
       q.Enqueue(intervals[0].end,intervals[0].end);

        for(int i =1;i<n;i++){
            if(q.Peek()<=intervals[i].start){
                q.Dequeue();
            }
            q.Enqueue(intervals[i].end,intervals[i].end);
        }

        return q.Count;
    }
}
