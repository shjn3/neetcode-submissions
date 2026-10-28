public class WordDictionary {
    public class Node{
        public bool endOfWord;
        public Dictionary<char,Node> children = new();
    }
    Node root;
    public WordDictionary() {
        root = new Node();
    }
    
    public void AddWord(string word) {
        Node t = root;
        foreach(var c in word){
            if(!t.children.ContainsKey(c)){
                t.children.Add(c,new Node());
            }
            t= t.children[c];
        }

        t.endOfWord = true;
    }
    
    public bool Search(string word) {
        return Search2(word,0,root);
    }

    public bool Search2(string word, int i, Node node){
        Node t =node;
        for(int j = i;j<word.Length;j++){
            if(word[j]=='.'){
                foreach(var n in t.children){
                    if(Search2(word,j+1,n.Value)){
                        return true;
                    }
                }
                return false;
            }
            if(!t.children.ContainsKey(word[j])){
                return false;
            }
            t= t.children[word[j]];
        }

        return t.endOfWord;
    }
}
