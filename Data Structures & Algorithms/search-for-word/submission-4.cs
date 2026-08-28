public class Solution {
    public bool Exist(char[][] board, string word) {
        int m = board.Length;
        int n = board[0].Length;
        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                if(word[0]!=board[i][j]) continue;
                var res = BackTracking(board, word, 0,i,j);
                if(res) return true;
            }
        }

        return false;
    }

    public bool BackTracking( char[][] board, string word, int i,int row,int col){

        if(row<0 ||row>=board.Length || col<0 || col>=board[0].Length) return false;
        if(board[row][col]!=word[i] || board[row][col]=='#'){
            return false;
        }

        if(i == word.Length-1){
          return true;
        }

        //Horizontal
        board[row][col]='#';

        var res = BackTracking(board,word,i+1,row+1,col)||  
        BackTracking(board,word,i+1,row-1,col) ||
        BackTracking(board,word,i+1,row,col+1) ||
        BackTracking(board,word,i+1,row,col-1);

        board[row][col] = word[i];
         return res;
    }
}
