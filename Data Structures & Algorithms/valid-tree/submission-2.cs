public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length==0) return true;
        Dictionary<int,List<int>> adj = new();
        for(int i = 0;i<edges.Length;i++){
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
        visiting.Add(edges[0][0]);
        if(!DFS(adj,visiting,edges[0][0],-1)){
            return false;
        }

        return visiting.Count == adj.Count;
    }

    bool DFS(Dictionary<int,List<int>> adj,HashSet<int> visiting,int current, int source){
        if(visiting.Count==adj.Count || adj[current].Count==0) return true;
        foreach(var m in adj[current]){
            if(m==source) continue;
            if(visiting.Contains(m)) return false;
            visiting.Add(m);
            if(!DFS(adj,visiting,m,current)){
                return false;
            }

        }
        return true;


    }
}
