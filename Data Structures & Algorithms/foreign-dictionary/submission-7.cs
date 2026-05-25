public class Solution {

    public class Node{
        public char value;
        public List<Node>preNodes = new();
        public void addPreviousNode(Node node){
            bool hasNode = this.preNodes.Contains(node);
            if(!hasNode){
                this.preNodes.Add(node);
            }
        }

        public bool hasNode(Node target){
             foreach(Node node in preNodes){
                if(node==target) return true;
                var _has = node.hasNode(target);
                if(_has) return true;
            }

            return false;
        }

        public bool isCircle(){
            return this.hasNode(this);
        }
    }

    public string foreignDictionary(string[] words) {
        if(words.Length==1){
            return words[0];
        }
        List<Node> nodes = new();
        string result ="";
        string addResult="";
        for(int i =0;i<words.Length;i++){
            for(int j =0;j<words[i].Length;j++){
                var char1 = words[i][j];
                int idChar = nodes.FindIndex(n=>n.value==char1);
                if(idChar==-1){
                    nodes.Add(new Node(){
                        value=char1
                    });
                }
            }
        }

        if(nodes.Count==0) return result;

        bool isValid =false;

        for(int i =0;i<words.Length-1;i++){
            var currentWord =words[i];
            var nextWord = words[i+1];
            int length1 = currentWord.Length;
            int length2 = nextWord.Length;
            if(length1>length2 && currentWord[0]==nextWord[0]) continue;
            isValid= true;
            int length = Math.Min(currentWord.Length,nextWord.Length);
            for(int j =0;j<length;j++){
                if(currentWord[j]==nextWord[j]) continue;
                var char1 = currentWord[j];
                var char2 = nextWord[j];
    
                int idChar1 = nodes.FindIndex(n=>n.value==char1);
                int idChar2 = nodes.FindIndex(n=>n.value==char2);
                Node char1Node = nodes[idChar1], char2Node= nodes[idChar2];

                char2Node.addPreviousNode(char1Node);
                if(char2Node.isCircle()){
                    return "";
                }  
                break;
            }
        }

        if(!isValid) return result;

        List<Node> visited =new List<Node>();


        while(nodes.Count>0){
            Node _node = nodes.Find(n=>n.preNodes.Count==0);
            if(_node==null){
                return "Node null";
            }
            result+=_node.value;

            visited.Add(_node);
            nodes.Remove(_node);
            foreach(var node in nodes){
                node.preNodes.Remove(_node);
            }
        }


        return result;
    }
}
