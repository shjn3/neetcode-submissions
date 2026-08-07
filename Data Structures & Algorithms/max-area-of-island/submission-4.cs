public class Solution {

    public int MaxAreaOfIsland(int[][] grid) {
        int max=0;
        for(int row=0;row<grid.Length;row++){
            for(int col =0;col<grid[0].Length;col++){
                if(grid[row][col]==1) {
                    max = Math.Max(max,dfs(row,col,grid));
                }
            }
        }
      
        return max;
    }

    public int dfs(int r, int c, int[][] grid){
        if(r<0 || r>=grid.Length || c<0 || c>=grid[0].Length || grid[r][c]!=1){
            return 0;
        }
        grid[r][c]=2; 
        int l1=  dfs(r,c+1,grid);
        int l3=  dfs(r,c-1,grid);
        int l4=  dfs(r-1,c,grid);
        int l2 = dfs(r+1,c, grid);

        return l1+l2+l3+l4+1;
    }
}
