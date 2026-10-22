public class Solution {
    int[][] offsets =new int[][]{
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

    int[][] dp;
    
    public int LongestIncreasingPath(int[][] matrix) {
        int n = matrix.Length;
        int m = matrix[0].Length;

        bool[][] visited = new bool[n][];
        dp = new int[n][];
        for(int  i=0;i<n;i++){
            visited[i]=new bool[m];
            dp[i] = new int[m];
            Array.Fill(dp[i],-1);
        }
        int res = 1;
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                res = Math.Max(res,DFS(matrix,i,j,int.MinValue));
            }
        }

        return res;
    }

    public int DFS(int[][] matrix, int r, int c,int prevVal){
        int n = matrix.Length;
        int m = matrix[0].Length;
        if(r<0 || r>=n || c<0 || c>=m || matrix[r][c]<=prevVal){
            return 0;
        }

        if(dp[r][c]!=-1){
            return dp[r][c];
        }

        int res =1;
        foreach(var offset in offsets){
            res = Math.Max(res,1+DFS(matrix,r+offset[0],c+offset[1],matrix[r][c]));
        }
        dp[r][c]=res;
       
        return res;
    }
}
