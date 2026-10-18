public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        Dictionary<string,List<string>> adj =new();
        int n = wordList.Count;
        for(int i =0;i<n-1;i++){
            string w = wordList[i];
            for(int j =i+1;j<n;j++){
                string w2 = wordList[j];
                if(!canTransform(w,w2)) continue;

                if(!adj.ContainsKey(w)){
                    adj.Add(w,new());
                }
                if(!adj.ContainsKey(w2)){
                    adj.Add(w2,new());
                }
                adj[w].Add(w2);
                adj[w2].Add(w);
            }
        }

        if(!adj.ContainsKey(endWord)){
            return 0;
        }

        if(!adj.ContainsKey(beginWord)){
            adj.Add(beginWord,new());
            for(int i =0;i<n;i++){
                if(canTransform(beginWord,wordList[i])){
                    adj[beginWord].Add(wordList[i]);
                    adj[wordList[i]].Add(beginWord);
                }
            }
        }

        List<string> temp = new();
        List<string> nextTemp = new();
        HashSet<string> visited = new();
        visited.Add(beginWord);
        temp.Add(beginWord);
        int count = 1;
        while(temp.Count>0){
          nextTemp.Clear();
          foreach(var element in temp){
            foreach(var nei in adj[element]){
                if(nei==endWord){
                    return count+1;
                }
                if(visited.Contains(nei)) continue;
                visited.Add(nei);
                nextTemp.Add(nei);
            }
          }
          var t = temp;
          temp = nextTemp;
          nextTemp = t;

          count++;
        }

        return 0;
    }

    public bool canTransform(string w1, string w2){
        int count = 0;
        for(int i =0;i<w1.Length;i++){
            if(w1[i]!=w2[i]){
                count++;
            }
            if(count>1) return false;
        }
        return true;
    }


}
