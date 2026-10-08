public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        PriorityQueue<(int,int),int>  pq = new();
        pq.Enqueue((0,0),grid[0][0]);
        int t= grid[0][0];

        bool[][] visited = new bool[n][];
        for(int i =0;i<n;i++){
            visited[i]=new bool[n];
        }

        visited[0][0]=true;

        int[][] offsets = new int[][]{
            new int[]{
                0,1
            },
             new int[]{
                0,-1
            },
                      new int[]{
                1,0
            },
                      new int[]{
                -1,0
            },
        };
        

        while(pq.Count>0){
            if(pq.TryDequeue(out (int,int) pos, out int elevation )){
                t = Math.Max(t,elevation);
                if(pos.Item1==n-1 && pos.Item2==n-1){
                    break;
                }

                foreach(var offset in offsets){
                    var nextR = pos.Item1+offset[0];
                    var nextC = pos.Item2+offset[1];
                    if(IsValid(n,nextR,nextC) && !visited[nextR][nextC]){
                        visited[nextR][nextC] = true;
                        pq.Enqueue((nextR,nextC),grid[nextR][nextC]);
                    }
                }
              
            }
        }

        return t;
    }

    public bool IsValid (int n ,int r, int c){
        return r>=0 && r<n &&c>=0 && c<n;
    }
}
