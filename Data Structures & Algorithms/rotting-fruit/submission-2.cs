public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] offsets = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{-1,0},
        };

        int freshCount = 0;
        Queue<int[]> q=  new();
        for(int i =0;i<m;i++){
            for(int j= 0;j<n;j++){
                if(grid[i][j]==1) freshCount++;
                if(grid[i][j]==2) q.Enqueue(new int[]{i,j});
            }
        }

        bool IsValid(int x, int y){
            return x>=0 && x<m && y>=0 && y<n;
        }
        int time =0;

        while(q.Count>0 && freshCount>0){
            int length = q.Count;
            for(int i =0;i<length;i++){
                var rotten = q.Dequeue();
                foreach(var offset in offsets){
                    int nextR = rotten[0]+offset[0];
                    int nextC = rotten[1]+offset[1];
                    if(!IsValid(nextR,nextC)) continue;
                    if(grid[nextR][nextC]==1){
                        grid[nextR][nextC]=2;
                        q.Enqueue(new int[]{nextR,nextC});
                        freshCount--;
                    }
                }
            }
            time++;
        }

    
        return freshCount==0? time:-1;
    }
}
