public class Solution {
    char[][] res;
    bool[][] visited;

    int[][] offsets = new int[][]{
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
        }
    };

    public void Solve(char[][] board) {
        int  m = board.Length;
        int n =board[0].Length;
        res = new char[m][];
        visited = new bool[m][];
        for(int i =0;i<m;i++){
            res[i] = new char[n];
            Array.Fill(res[i],'X');
            visited[i] = new bool[n];
        }
        for(int i =0;i<m;i++){
            DFS(board,i,0);
            DFS(board,i,n-1);
        }

        for(int i =0;i<n;i++){
            DFS(board,0,i);
            DFS(board,m-1,i);
        }

        for(int i =0;i<m;i++){
            Array.Copy(res[i],board[i],n);
        }
    }



    public void DFS(char[][] board, int r, int c){
        if(r<0 ||r>=board.Length ||c<0 || c>=board[0].Length) return;
        if(board[r][c]=='X' || visited[r][c]) return;
        res[r][c]=board[r][c];
        visited[r][c] = true;

        foreach(var offset in offsets){
            int nR = r+offset[0];
            int nC=  c+offset[1];
            DFS(board,nR,nC);
        }

    }
}
