public class Solution {
    HashSet<int> res = new();
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> adj = new();
        int n = prerequisites.Length;
        for(int i =0;i<n;i++){
            var p = prerequisites[i];
            if(!adj.ContainsKey(p[0])){
                adj.Add(p[0],new());
            }
            if(!adj.ContainsKey(p[1])){
                adj.Add(p[1],new());
            }

            adj[p[0]].Add(p[1]);
        }
        HashSet<int> visiting = new();

        for(int i = numCourses-1;i>=0;i--){
            if(!adj.ContainsKey(i)){
                res.Add(i);
                continue;
            }

            if(!DFS(adj,visiting,i)){
                return new int[0];
            }
        }


        return res.ToArray();
    }

    public bool DFS(Dictionary<int, List<int>> adj, HashSet<int> visiting, int current){

        foreach(var n in adj[current]){
            if(visiting.Contains(n)) return false;
            visiting.Add(n);
            if(!DFS(adj,visiting,n)){
                return false;
            }
            res.Add(n);
            visiting.Remove(n);
        }

        res.Add(current);
        adj[current].Clear();
        return true;
    }
}
