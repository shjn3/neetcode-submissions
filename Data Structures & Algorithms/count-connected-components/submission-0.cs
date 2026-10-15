public class Solution {
    public class USC {
        public int[] parent;
        public USC(int n){
            parent = new int[n];
            for(int i =0;i<n;i++){
                parent[i] = i;
            }
        }

        public int find(int v){
            if(parent[v]!=v){
                parent[v] = find(parent[v]);
            }

            return parent[v];
        }

        public void Union(int a, int b){
            var rootA = find(a);
            var rootB = find(b);
            if(rootA==rootB) return;
            parent[rootA] = rootB;
        }
    }

    public int CountComponents(int n, int[][] edges) {
        USC union = new USC(n);
        for(int i =0;i<edges.Length;i++){
            var edge = edges[i];
            union.Union(edge[0],edge[1]);
        }
        HashSet<int> s =new();
        for(int i =0;i<n;i++){
            s.Add(union.find(i));
        }

        return s.Count;
    }
}
