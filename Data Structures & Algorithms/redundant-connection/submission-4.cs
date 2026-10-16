public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        Dictionary<int, List<int>> adj = new();
        int n =edges.Length;
        for(int i =0;i<n;i++){
            var edge = edges[i];
            if(!adj.ContainsKey(edge[0])){
                adj.Add(edge[0],new());
            }

            if(!adj.ContainsKey(edge[1])){
                adj.Add(edge[1],new());
            }

            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        HashSet<int> visiting = new();
        int res = 0;
        for(int i =n-1;i>0;i--){
            visiting.Clear();
            visiting.Add(edges[i][0]);
            if(DFS(adj,visiting,edges[i][0],-1,edges[i])&& visiting.Count==adj.Count){
                res=i;
                break;
            }
        }

        return edges[res];
    }

    public bool DFS( Dictionary<int, List<int>> adj, HashSet<int> visiting, int current,int prev, int[] excludeEdge){
        if(adj.Count== visiting.Count || adj[current].Count==0) return true;

        foreach(var n in adj[current]){
            if(n==excludeEdge[0]  && current == excludeEdge[1] 
            || (n==excludeEdge[1]  && current == excludeEdge[0]) || n==prev) continue;
            if(visiting.Contains(n)) return false;
            visiting.Add(n);
            if(!DFS(adj,visiting,n,current,excludeEdge)){
                return false;
            }
        }
        return true;
    }
}
