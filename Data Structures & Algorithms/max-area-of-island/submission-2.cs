public class Solution {

    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m*n;
        int max=0;
        bool[][] visited = new bool[m][];
        for(int i =0;i<m;i++){
            visited[i]=new bool[n];
        }

        for(int row=0;row<m;row++){
            for(int col =0;col<n;col++){
                if(grid[row][col]==0 || visited[row][col]) continue;
                int l = dfs(row,col,0,visited,grid);
                max = Math.Max(l,max);
            }
        }
      
        return max;
    }

    public int dfs(int r, int c, int length,bool[][] visited, int[][] grid){
        if(r<0 || r>=grid.Length || c<0 || c>=grid[0].Length || visited[r][c] || grid[r][c]==0){
            return length;
        }

        visited[r][c]=true;
        int l1=  dfs(r,c+1,length, visited,grid);
        int l3=  dfs(r,c-1,length, visited,grid);
        int l4=  dfs(r-1,c,length, visited,grid);

        int l2 = dfs(r+1,c,length,visited, grid);
        // Console.WriteLine("L: "+l1+" "+l2+" "+r+" "+c);

        return l1+l2+l3+l4+1;
    }
}
