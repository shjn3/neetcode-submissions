public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int n = prerequisites.Length;
        int[] required = new int[numCourses];
        Dictionary<int, List<int>> adj = new();

        for(int i =0;i<n;i++){
            var p = prerequisites[i];
            if(!adj.ContainsKey(p[0])){
                adj.Add(p[0],new());
            }

            if(!adj.ContainsKey(p[1])){
                adj.Add(p[1],new());
            }

            adj[p[1]].Add(p[0]);
            required[p[0]]++;
        }
        Queue<int> q = new();
        for(int i =numCourses-1;i>=0;i--){
            if(required[i]==0){
                q.Enqueue(i);
            }
        }
        HashSet<int> res = new();
        while(q.Count>0){
            var v = q.Dequeue();
            res.Add(v);
            if(!adj.ContainsKey(v)) continue;
            foreach(var adjV in adj[v]){
                required[adjV]--;
                if(res.Contains(adjV)) return new int[0];
                if(required[adjV]==0){
                    q.Enqueue(adjV);
                }
            }
        }

        return res.Count==numCourses?res.ToArray():new int[0];
    }
}
