public class Solution {

    public class DSU{
        public int[] parent,size;
        public DSU(int n){
            parent = new int[n+1];
            size = new int[n+1];
            for(int i=0;i<=n;i++){
                parent[i] = i;
            }
            Array.Fill(size,1);
        }

        public int Find(int v){
            if(parent[v]!=v){
                parent[v] = Find(parent[v]);
            }

            return parent[v];
        }

        public bool Union(int u, int v){
            int pu  = Find(u), pv = Find(v);
            if(pu==pv) return false;
            if(size[pu]<size[pv]){
                int temp = pu;
                pu= pv;
                pv = temp;
            }

            size[pu]+=size[pv];
            parent[pv]=pu;
            return true;
        }


    }
 
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length;
        DSU dsu = new(n);
        List<(int,int,int)> edges = new ();
        for(int i=0;i<n;i++){
            for(int j =i+1;j<n;j++){
               var d = CalculateManhattanDistance(points[i],points[j]);
                edges.Add((d,i,j));
            }
        }

        edges.Sort((a,b)=>a.Item1.CompareTo(b.Item1));
        int res = 0;
        foreach(var edge in edges){
            if(dsu.Union(edge.Item2,edge.Item3)){
                res+=edge.Item1;
            }
        }
        
    
        return res;
    }

    public int CalculateManhattanDistance(int[] point1, int[] point2){
        return Math.Abs(point1[0]-point2[0])+Math.Abs(point1[1]-point2[1]);
    }
}
