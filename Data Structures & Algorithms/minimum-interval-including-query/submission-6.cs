public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        List<int[]> events = new();
        for(int i =0;i<intervals.Length;i++){
            int l = intervals[i][1]-intervals[i][0]+1;
            events.Add(new int[]{
                intervals[i][0],0,l,i
            });
            events.Add(new int[]{
                intervals[i][1],2,l,i
            });
        }
        for(int i =0;i<queries.Length;i++){
            events.Add(new int[]{
                queries[i],1,i
            });
        }

        events.Sort((a,b)=>a[0]==b[0]?a[1].CompareTo(b[1]):a[0].CompareTo(b[0]));

        int[] ans = new int[queries.Length];
        Array.Fill(ans,-1);
        PriorityQueue<(int size, int idx),int> q = new();
        bool[] inactive = new bool[intervals.Length];

        for(int i =0;i<events.Count;i++){
            if(events[i][1]==0){
                q.Enqueue((events[i][2],events[i][3]),events[i][2]);
            }else if (events[i][1]==2){
                inactive[events[i][3]] = true;
            }else{
                int queryIdx = events[i][2];
                while(q.Count>0 && inactive[q.Peek().idx]){
                    q.Dequeue();
                }

                if(q.Count>0){
                    ans[queryIdx] = q.Peek().size;
                }
            }

        }


  
        return ans;
    }
}
