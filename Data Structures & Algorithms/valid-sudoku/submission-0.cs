public class Solution {
    public bool IsValidSudoku(char[][] board) {
        HashSet<char> _hash =  new HashSet<char>();
        char dot = '.';
        //Check Row
        for(int i =0;i<9;i++){
            _hash.Clear();
            for(int j =0;j<9;j++){
                char c = board[i][j];
                if(c==dot) continue;
                if(_hash.Contains(c)) return false;
                _hash.Add(c);
            }
        }

        //Check Col
        for(int i =0;i<9;i++){
            _hash.Clear();
            for(int j =0;j<9;j++){
                char c = board[j][i];
                if(c==dot) continue;
                if(_hash.Contains(c)) return false;
                _hash.Add(c);

            }
        }


        //Check Chunk
        for(int chunkI =0;chunkI<3;chunkI++){
            for(int chunkJ=0;chunkJ<3;chunkJ++){
                _hash.Clear();

                for(int i =0;i<3;i++){
                    int startI = chunkI*3+i;
                    for(int j =0;j<3;j++){
                        int startJ = chunkJ*3+j;
                        char c = board[startI][startJ];
                        if(c==dot) continue;
                        if(_hash.Contains(c)) return false;
                         _hash.Add(c);

                    }
                }
            }
        }

        return true;
    }

}
