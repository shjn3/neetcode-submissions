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

    public List<List<int>> PacificAtlantic(int[][] heights) {
        bool[][] visited = new bool[heights.Length][];
        for(int i =0;i<heights.Length;i++){
            visited[i] = new bool[heights[0].Length];
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

    public bool DFSPacific(int[][] heights, int r, int c,int prevHeight,bool[][] visited){
        if(r<0 || c<0) return true;
        if(r>=heights.Length || c>=heights[0].Length) return false;
        if(visited[r][c]) return false;
        if(heights[r][c]>prevHeight) return false;

        visited[r][c]=true;
        foreach(var offset in offsets){
            int nR = r +offset[0];
            int nC = c+offset[1];
            if(DFSPacific(heights,nR,nC,heights[r][c],visited)){
                return true;
            }
        }
        return false;
    }

    public bool DFSAtlantic(int[][] heights,int r, int c,int prevHeight,bool[][] visited){
        if(r<0 || c<0) return false;
        if(r>=heights.Length || c>=heights[0].Length) return true;
        if(visited[r][c]) return false;
        if(heights[r][c]>prevHeight) return false;
        visited[r][c]=true;
        foreach(var offset in offsets){
            int nR = r +offset[0];
            int nC = c+offset[1];
            if(DFSAtlantic(heights,nR,nC,heights[r][c],visited)){
                return true;
            }
        }
        return false;
    }
}
