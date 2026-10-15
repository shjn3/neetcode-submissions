public class Solution {
   

    public int CountComponents(int n, int[][] edges) {
      List<List<int>> adj = new(n);
      for(int i =0;i<n;i++){
        adj.Add(new());
      }
      for(int i =0;i<edges.Length;i++){
        var edge = edges[i];
        adj[edge[0]].Add(edge[1]);
        adj[edge[1]].Add(edge[0]);
      }

      HashSet<int> visiting = new();
      int count =0;
      for(int i =0;i<n;i++){
        if(visiting.Contains(i)) continue;
        count++;
        visiting.Add(i);
        DFS(adj,visiting,i);
      }

      return count;
    }

    public void DFS(List<List<int>> adj,HashSet<int> visiting, int current){
        if(adj[current].Count==0) return;
        foreach(var n in adj[current]){
            if(visiting.Contains(n)) continue;
            visiting.Add(n);
            DFS(adj,visiting,n);
        }
    }
}
