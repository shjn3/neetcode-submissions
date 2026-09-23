public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        List<int[]> events = new();
        for(int i =0;i<intervals.Length;i++){
            int l = intervals[i][1]-intervals[i][0]+1;
            events.Add(new int[]{
                intervals[i][0],
                0,l,i
            });
             events.Add(new int[]{
                intervals[i][1],
                2,l,i
            });
        }

        for(int j =0;j<queries.Length;j++){
            events.Add(new int[]{
                queries[j],
                1,j
            });
        }

        events.Sort((a,b)=>a[0]==b[0]?a[1].CompareTo(b[1]):a[0].CompareTo(b[0]));

        int[] ans = new int[queries.Length];
        Array.Fill(ans,-1);
        bool[] inactive = new bool[intervals.Length];
        PriorityQueue<(int size, int idx),int> q = new();

        for(int i =0;i<events.Count;i++){
            var e = events[i];
            if(e[1]==0){
                q.Enqueue((e[2],e[3]),e[2]);
            }else if (e[1]==2){
                inactive[e[3]]=true;
            }
            else{
                int qId = e[2];
                while(q.Count>0 && inactive[q.Peek().idx]){
                    q.Dequeue();
                }

                if(q.Count>0){
                    ans[qId] = q.Peek().size;
                }
            }
        }

        return ans;
    }
}
