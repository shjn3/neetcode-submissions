public class Solution {
    int[][] offsets = new int[][]{
        new int[]{
            0,1
        },
        new int[]{
            0,-1
        },
                new int[]{
            1,0
        },        new int[]{
            -1,0
        }
    };
    int[][] dp;

    public List<List<int>> PacificAtlantic(int[][] heights) {
        bool[][] visited = new bool[heights.Length][];
        dp  = new int[heights.Length][];
        for(int i =0;i<heights.Length;i++){
            visited[i] = new bool[heights[0].Length];
            dp[i] = new int[heights[0].Length];
        }
         List<List<int>> ans = new();

        for(int  i=0;i<heights.Length;i++){
            for(int j =0;j<heights[i].Length;j++){
               ResetVisited(visited);
               bool res1= DFSPacific(heights,i,j,heights[i][j],visited);
               if(!res1) continue;
               ResetVisited(visited);
               bool res2=  DFSAtlantic(heights,i,j,heights[i][j],visited);
               if(res2){
                ans.Add(new List<int>(){i,j});
               }
            }
        }

        return ans;
    }  

    public void ResetVisited(bool[][] visited){
        for(int i =0;i<visited.Length;i++){
            Array.Fill(visited[i],false);
        }
    } 
    int canPacific =1;
    int canAtlantic =2;
    int canBoth =3;
    int cannot =-1;

    public bool DFSPacific(int[][] heights, int r, int c,int prevHeight,bool[][] visited){
        if(r<0 || c<0) return true;
        if(r>=heights.Length || c>=heights[0].Length) return false;
        if(visited[r][c]) return false;
        if(heights[r][c]>prevHeight) return false;
        // if(dp[r][c]==cannot) return false;
        
        if(dp[r][c]== canPacific || dp[r][c]==canBoth) return true;
        visited[r][c]=true;
        foreach(var offset in offsets){
            int nR = r +offset[0];
            int nC = c+offset[1];
            if(DFSPacific(heights,nR,nC,heights[r][c],visited)){
                dp[r][c]=dp[r][c]==canAtlantic?canBoth:canPacific;
                return true;
            }
        }

        // dp[r][c]=cannot;
        return false;
    }

    public bool DFSAtlantic(int[][] heights,int r, int c,int prevHeight,bool[][] visited){
        if(r<0 || c<0) return false;
        if(r>=heights.Length || c>=heights[0].Length) return true;
        if(visited[r][c]) return false;
        if(heights[r][c]>prevHeight) return false;

        // if(dp[r][c]==cannot) return false;
        if(dp[r][c]== canAtlantic || dp[r][c]==canBoth) return true;

        visited[r][c]=true;
        foreach(var offset in offsets){
            int nR = r +offset[0];
            int nC = c+offset[1];
            if(DFSAtlantic(heights,nR,nC,heights[r][c],visited)){
                dp[r][c]=dp[r][c]==canPacific?canBoth:canAtlantic;
                return true;
            }
        }
        // dp[r][c]=cannot;
        return false;
    }
}
