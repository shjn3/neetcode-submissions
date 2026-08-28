public class Solution {
    public bool Exist(char[][] board, string word) {
        int m = board.Length;
        int n = board[0].Length;

        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                bool[][] visited = new bool[m][];
                for(int k =0;k<m;k++){
                    visited[k] = new bool[n];
                }
                var res = BackTracking(board,visited, word, 0,i,j);
                if(res) return true;
            }
        }

        return false;
    }

    public bool BackTracking( char[][] board, bool[][] visited, string word, int i,int row,int col){

        if(row<0 ||row>=board.Length || col<0 || col>=board[0].Length
        ||visited[row][col]) return false;
        if(board[row][col]!=word[i]){
            return false;
        }

        if(i == word.Length-1){
          return true;
        }

        //Horizontal
        visited[row][col] = true;
   var res = BackTracking(board,visited,word,i+1,row+1,col)||  
   BackTracking(board,visited,word,i+1,row-1,col) ||
   BackTracking(board,visited,word,i+1,row,col+1) ||
   BackTracking(board,visited,word,i+1,row,col-1);
   visited[row][col]=false;
   return res;
    }
}
