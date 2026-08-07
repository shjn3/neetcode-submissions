public class Solution {

    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m*n;
        int max=0;
   

        for(int row=0;row<m;row++){
            for(int col =0;col<n;col++){
                if(grid[row][col]!=1) continue;
                int l = dfs(row,col,0,grid);
                max = Math.Max(l,max);
            }
        }
      
        return max;
    }

    public int dfs(int r, int c, int length, int[][] grid){
        if(r<0 || r>=grid.Length || c<0 || c>=grid[0].Length || grid[r][c]!=1){
            return length;
        }
        grid[r][c]=2; 
        int l1=  dfs(r,c+1,length,grid);
        int l3=  dfs(r,c-1,length,grid);
        int l4=  dfs(r-1,c,length,grid);
        int l2 = dfs(r+1,c,length, grid);

        return l1+l2+l3+l4+1;
    }
}
