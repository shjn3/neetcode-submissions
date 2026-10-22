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

    
    public int LongestIncreasingPath(int[][] matrix) {
     int ROWS = matrix.Length;
     int COLS = matrix[0].Length;
     int[][] indegree = new int[ROWS][];
     for(int i =0;i<ROWS;i++){
        indegree[i] = new int[COLS];
     }     

     for(int i =0;i<ROWS;i++){
        for(int j =0;j<COLS;j++){
            foreach(var d in offsets){
                int nr = i+d[0], nc = j+d[1];
                if(nr<0 || nr>=ROWS || nc<0 || nc>=COLS) continue;
                if(matrix[nr][nc]>=matrix[i][j]) continue;
                indegree[i][j]++;
            }
        }
     }

     Queue<int[]> q = new();
     for(int i =0;i<ROWS;i++){
        for(int j =0;j<COLS;j++){
          if(indegree[i][j]==0){
            q.Enqueue(new int[]{
                i,j
            });
          }
        }
     }
    int res =0;
     while(q.Count>0){
        int size =q.Count;
        for(int i =0;i<size;i++){
            var node = q.Dequeue();
            int r= node[0], c = node[1];
            foreach(var d in offsets){
                int nr = r+d[0], nc = c+d[1];
                if(nr<0 || nr>=ROWS || nc<0 || nc>=COLS) continue;
                if(matrix[nr][nc]<=matrix[r][c]) continue;
                if(--indegree[nr][nc]==0){
                    q.Enqueue(new int[]{
                        nr,nc
                    });
                }
            }
        }
        res++;
     }


    return res;


    }
}
