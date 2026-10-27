public class PrefixTree {
    public class Node{
        public char value;
        public bool end;
        public Dictionary<char,Node> children = new();
    }
    Node root;

    public PrefixTree() {
        root = new Node();
    }
    
    public void Insert(string word) {
        Node t = root;
        int i =0;
        int n = word.Length;
        while(i<n){
            if(!t.children.ContainsKey(word[i])){
                t.children.Add(word[i],new Node(){
                    value = word[i]
                });
            }
            t= t.children[word[i]];
            i++;
        }
        if(t!=root){
            t.end =true;
        }
    }
    
    public bool Search(string word) {
        int  i=0;
        int n = word.Length;
        Node t = root;
        while(i<n){
            if(!t.children.ContainsKey(word[i])){
                return false;
            }

            t= t.children[word[i]];
            i++;
        }

        return t.children.Count==0 || t.end;
    }
    
    public bool StartsWith(string prefix) {
        int  i=0;
        int n = prefix.Length;
        Node t = root;
        while(i<n){
            if(!t.children.ContainsKey(prefix[i])){
                return false;
            }

            t= t.children[prefix[i]];
            i++;
        }

        return true;
    }
}
