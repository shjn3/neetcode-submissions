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
        }
        int res = 0;
        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                ResetVisited(visited);
                ResetDP();
                res = Math.Max(res,DFS(matrix,visited,i,j,0));
                //   for(int k=0;k<n;k++){
                //         string a ="";
                //         for(int l=0;l<m;l++){
                //         a+=dp[k][l]+ " ";
                //         }
                //         Console.WriteLine("A: "+a);
                //     }
            }
        }

        return res;
    }

    public void ResetDP(){
        int n = dp.Length;
        int m = dp[0].Length;
        for(int i =0;i<n;i++){
            for(int j=0;j<m;j++){
                dp[i][j]=0;
            }
        }
    }

    public void ResetVisited(bool[][] visited){
        int n = visited.Length;
        int m = visited[0].Length;
        for(int i =0;i<n;i++){
            for(int j =0;j<m;j++){
                visited[i][j]=false;
            }
        }
    }

    public int DFS(int[][] matrix, bool[][] visited,int r, int c,int total){
        if(dp[r][c]!=0){
            return dp[r][c];
        }
        int currentValue = matrix[r][c];
        dp[r][c] =1;
        foreach(var offset in offsets){
            var nextR = r +offset[0];
            var nextC = c+offset[1];
            if (nextR<0 || nextC<0 || nextR>=matrix.Length || nextC>=matrix[0].Length) continue;
            if (matrix[nextR][nextC]<=currentValue || visited[nextR][nextC]) continue;
            visited[nextR][nextC]=true;
            dp[r][c] = Math.Max(DFS(matrix,visited,nextR,nextC,total+1)+1,dp[r][c]);
            visited[nextR][nextC]=false;
        }

        return dp[r][c];
    }
}
