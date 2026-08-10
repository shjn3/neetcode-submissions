public class Solution {
    int m;
    int n;

    public bool isValid(int row, int col){
        return row>=0 && row<m && col>=0 && col<n;
    }

    public int[][] offsets = new int[][]{
        new int[]{
            1,0
        },
            new int[]{
            -1,0
        },    new int[]{
            0,1
        },    new int[]{
            0,-1
        },
    };

    public void islandsAndTreasure(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;
        Queue<(int,int)> q = new(); 
        HashSet<(int,int)> visited = new();

        for(int row = 0;row<m;row++){
            for(int col =0;col<n;col++){
                if(grid[row][col]!=0) continue;
                q.Enqueue((row,col));
                // visited.Add((r1,c1));
                while(q.Count>0){
                  (var r1,var c1) = q.Dequeue();
                  int length =grid[r1][c1]+1;
                  
                    foreach(var offset in offsets){
                        var nextR = r1+offset[0];
                        var nextC = c1+offset[1];
                        if(!isValid(nextR,nextC)){
                            continue;
                        }
                        if(grid[nextR][nextC]<=length) continue;
                        grid[nextR][nextC] = length;
                        q.Enqueue((nextR,nextC));
                        // visited.Add((nextR,nextC));
                    }
                }
            }
        }
    }
}
