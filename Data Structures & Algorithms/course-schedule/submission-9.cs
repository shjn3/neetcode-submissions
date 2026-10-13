public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if(prerequisites.Length==0) return true;
        Dictionary<int, List<int>> adj = new();
        int n = prerequisites.Length;
        for(int i =0;i<n;i++){
            var  p =prerequisites[i];
            if(!adj.ContainsKey(p[0])){
                adj.Add(p[0],new());
            }
            if(!adj.ContainsKey(p[1])){
                adj.Add(p[1],new());
            }

            adj[p[0]].Add(p[1]);
        }
        var visiting =new HashSet<int>();
        for(int i =0;i<numCourses;i++){
            if(!adj.ContainsKey(i)) continue;
            visiting.Add(i);
            if(!DFS(adj,i,new())){
                return false;
            }
            visiting.Remove(i);
        }

        return true;
    }

    public bool DFS(Dictionary<int, List<int>> adj, int current,HashSet<int>visiting){
        if(adj[current].Count==0){
            return true;
        }

        foreach(var n in adj[current]){
            if(visiting.Contains(n)) return false;
            visiting.Add(n);
            if(!DFS(adj,n,visiting)){
                 return false;
            }
            visiting.Remove(n);
        }

        adj[current].Clear();

        return true;
    }
    
}
