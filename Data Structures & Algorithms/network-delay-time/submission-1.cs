public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<(int node,int t)>> graph =new(n+1);
        for(int i =0;i<times.Length;i++){
            var time = times[i];
            int s = time[0];
            if(!graph.ContainsKey(s)){
                graph.Add(s,new());
            }
            graph[s].Add((time[1],time[2]));
        }

        int[] dist = new int[n+1];
        Array.Fill(dist,int.MaxValue);
        PriorityQueue<int,int> pq = new();
        dist[0]=-1;
        dist[k] = 0;
        pq.Enqueue(k,0);

        while(pq.Count>0){
            if(pq.TryDequeue(out int temp, out int priority)){
                if(priority>dist[temp]) continue;
            }

            if(graph.TryGetValue(temp, out var neighbors)){
                foreach(var neighbor in  neighbors){
                    if(dist[neighbor.node]>dist[temp]+neighbor.t){
                    dist[neighbor.node] =  dist[temp]+neighbor.t;
                    pq.Enqueue(neighbor.node,dist[neighbor.node]);
                    }
                } 
            }
        }

        int max = -1;
        for(int i =0;i<dist.Length;i++){
            if(dist[i]==int.MaxValue) return -1;
            max = Math.Max(max,dist[i]);
        }

        return max;
    }
}
