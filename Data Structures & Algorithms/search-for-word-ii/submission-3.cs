public class Solution {
    
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
    public class Node{
        public Node[] children = new Node[26];
        public int refs =0;
        public int idx = -1;
        public void AddWord(string word, int i){
            Node cur = this;
            cur.refs++;
            foreach(var c in word){
                int index = c-'a';
                if(cur.children[index]==null){
                    cur.children[index]= new Node();
                }
                cur = cur.children[index];
                cur.refs++;
            }
            cur.idx = i;
        }
    }
    List<string> res = new();
    Node root;
    public List<string> FindWords(char[][] board, string[] words) {
        root = new();
        for(int i =0;i<words.Length;i++){
            root.AddWord(words[i],i);
        }
       
        for(int i =0;i<board.Length;i++){
            for(int j =0;j<board[0].Length;j++){
                root.refs-= DFS(board,root,i,j,words);
            }
        }

        return res;
    }


    public int DFS(char[][] board,Node node,  int r, int c,string[] words){
        if(r<0 || r==board.Length || c<0 || c==board[0].Length 
    || board[r][c] =='*' || node.children[board[r][c]-'a']==null
    ) return 0;
       char temp = board[r][c];
       board[r][c]= '*';
       Node prev = node;
       node = node.children[temp-'a'];
       int found =0;
       if(node.idx!=-1){
        res.Add(words[node.idx]);
        node.idx =-1;
        found++;
       }

       found += DFS(board,node,r+1,c,words);
       found += DFS(board,node,r,c+1,words);
       found += DFS(board,node,r-1,c,words);
       found += DFS(board,node,r,c-1,words);

       board[r][c]= temp;
       node.refs -=found;
       if(node.refs==0){
            prev.children[temp-'a']=null;
       }

       return found;
    }

    

}
