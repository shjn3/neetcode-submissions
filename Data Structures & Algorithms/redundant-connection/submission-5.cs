public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
      int n = edges.Length;
      List<List<int>> adj = new List<List<int>>();
      for(int i =0;i<=n;i++){
        adj.Add(new List<int>());
      }

      foreach(var edge in edges){
        int u = edge[0], v = edge[1];
        adj[u].Add(v);
        adj[v].Add(u);
        bool[] visit = new bool[n+1];
        if(DFS(u,-1,adj,visit)){
            return new int[]{
                u,v
            };
        }
      }
      return new int[0];
    }

    private bool DFS(int node, int parent, List<List<int>> adj, bool[] visit){
        if(visit[node]) return true;
        visit[node] = true;
        foreach(int nei in adj[node]){
            if(nei==parent) continue;
            if(DFS(nei,node,adj,visit)) return true;
        }
        return false;
    }

}
