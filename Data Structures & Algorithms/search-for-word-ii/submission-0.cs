public class Solution {
    public class Node{
        public Dictionary<char,Node> map  =new();
        public bool endOfWord;
        public string w;
    }
    HashSet<string> resArr = new();
    Node root;
    public List<string> FindWords(char[][] board, string[] words) {
        root = new();
        foreach(var word in words){
            InsertWord(word);
        }
        int m = board[0].Length;

        bool[][] visited = new bool[board.Length][];
        for(int i =0;i<board.Length;i++){
            visited[i] = new bool[m];
        }

        for(int i =0;i<board.Length;i++){
            for(int j =0;j<m;j++){
                 DFS(board,visited,i,j,root);

                 for(int k = 0;k<board.Length;k++){
                    for(int l =0;l<m;l++){
                        visited[k][l] = false;
                    }
                 }


            }
        }

        return resArr.ToList();
    }


    public int[][] offsets = new int[][]{
        new int[]{
            0,1
        },new int[]{
            0,-1
        },new int[]{
            1,0
        },new int[]{
            -1,0
        },
    };

    public void DFS(char[][] board, bool[][] visited, int r, int c,Node previous){
        if(r<0 || r==board.Length || c<0 || c==board[0].Length || visited[r][c]) return;
        char character = board[r][c];
        if(!previous.map.ContainsKey(character)) return;
        Node node = previous.map[character];
        if(node.endOfWord){
            resArr.Add(node.w);
        }
        visited[r][c] = true;
        foreach(var offset in offsets){
            DFS(board,visited,r+offset[0],c+offset[1],node);
        }
        visited[r][c]=false;
    }

    

    public void InsertWord(string word){
        Node cursor = root;
        foreach(var c in word){
            if(!cursor.map.ContainsKey(c)){
                cursor.map.Add(c,new Node());
            }
            cursor = cursor.map[c];
        }
        cursor.endOfWord =true;
        cursor.w = word;
    }
}
