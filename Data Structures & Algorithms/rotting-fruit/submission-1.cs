public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int count = 0;
        int[][] offsets = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{-1,0},
        };

        int freshCount = 0;
        for(int i =0;i<m;i++){
            for(int j= 0;j<n;j++){
                if(grid[i][j]==1) freshCount++;
            }
        }

        bool IsValid(int x, int y){
            return x>=0 && x<m && y>=0 && y<n;
        }
        while(true){
            List<(int,int)> rottens = new();
            for(int i =0;i<m;i++){
                for(int j=0;j<n;j++){
                    if(grid[i][j]!=2) continue;
                    bool canInject = false;
                    foreach(var offset in offsets){
                        int nextR = i +offset[0];
                        int nextC = j+offset[1];
                        if(!IsValid(nextR,nextC)) continue;
                        if(grid[nextR][nextC]==1){
                            canInject = true;
                            break;
                        }
                    }
                    if(canInject){
                        rottens.Add((i,j));
                    }
                }
            }

            if(rottens.Count==0) break;
            count++;

            foreach(var rotten in rottens){
                int row = rotten.Item1;
                int col = rotten.Item2;
                foreach(var offset in offsets){
                    int nextR =row+offset[0];
                    int nextC = col+offset[1];
                    if(!IsValid(nextR,nextC)) continue;
                    if(grid[nextR][nextC]==1){
                        grid[nextR][nextC]=2;
                        freshCount--;
                    }
                }
            }
        }

        return freshCount!=0?-1:count;
    }
}
