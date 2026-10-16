public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
     int n = edges.Length;
     int[] par = new int[n+1];
     int[] rank = new int[n+1];
     for(int i =0;i<n;i++){
        par[i]=i;
        rank[i]=1;
     }

     foreach(var edge in edges){
        if(!Union(par,rank, edge[0],edge[1])){
            return new int[]{
                edge[0],edge[1]
            };
        }
     }

     return new int[0];

    
    }

    public int Find(int[] par, int n){
        if(par[n]!=n){
            par[n] = Find(par,par[n]);
        }

        return par[n];
    }

    public bool Union(int[] par, int[] rank, int n1, int n2){
        int p1 = Find(par,n1);
        int p2 = Find(par,n2);
        if(p1==p2) return false;

        if(rank[p1]>rank[p2]){
            par[p2] = p1;
            rank[p1]+=rank[p2];
        }else{
            par[p1] = p2;
            rank[p2]+=rank[p1];
        }
        return true;
    }
}
