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
        },
        new int[]{
            -1,0
        }
    };

    public class USC {
        public int[] parent;

        public USC(int w,int c){
            int l = w*c;

            parent  = new int[l];
            for(int i =0;i<l;i++){
                parent[i] = i;
            }
        }

        public int find(int v){
            if(parent[v]!=v){
                parent[v] = find(parent[v]);
            }

            return parent[v];
        }

        public void Union(int a,int b){
            var rootA = find(a);
            var rootB = find(b);
            if(rootA==rootB) return;
            parent[rootA] = rootB;
        }

    }

    public void Solve(char[][] board) {
        int m = board.Length;
        int n = board[0].Length;
        USC unique = new USC(m,n);

        for(int i=0;i<m;i++){
            for(int j =0;j<n;j++){
                if(board[i][j]!='O') continue;
                int idA = i*n+j;
                foreach(var offset in offsets){
                    int nR = i+offset[0];
                    int nC = j+offset[1];
                    if(nR<0 || nR>=m || nC<0 || nC>=n) continue;
                    if(board[nR][nC]!='O') continue;

                    int idB = nR*n+nC;
                    unique.Union(idA,idB);
                }
            }
        }

        HashSet<int> valid = new();
        for(int i =0;i<m;i++){
            if(board[i][0]=='O'){
                valid.Add(unique.find(i*n));
            }

            if(board[i][n-1]=='O'){
                valid.Add(unique.find(i*n+n-1));
            }
        }

       for(int i =0;i<n;i++){
            if(board[0][i]=='O'){
                valid.Add(unique.find(i));
            }

            if(board[m-1][i]=='O'){
                valid.Add(unique.find((m-1)*n+i));
            }
        }

        for(int i =0;i<m;i++){
            for(int j=0;j<n;j++){
                var v = unique.find(i*n+j);
                if(valid.Contains(v)){
                    board[i][j]='O';
                }else{
                    board[i][j]='X';
                }
            }
        }
    }
}
