public class Solution {
    public string foreignDictionary(string[] words) {
      var graph = new Dictionary<char,HashSet<char>>();
      foreach(var word in words){
        foreach(var c in word){
            if(graph.ContainsKey(c)) continue;
            graph.Add(c,new HashSet<char>());
        }
      }

      for(var i=1;i<words.Length;i++){
        var w1 = words[i-1];
        var w2 = words[i];
        for(var j =0;j<w1.Length;j++){
            if(j>=w2.Length) return "";
            if(w1[j]!=w2[j]){
                graph[w1[j]].Add(w2[j]);
                break;
            }
        }
      }

      var result = new Stack<char>();
      var seen = new Dictionary<char,bool>();
      bool dfsSearch(char k){

        if(seen.ContainsKey(k)){
            return seen[k];
        }
        seen.Add(k,true);

        foreach(var c in graph[k]){
            if(dfsSearch(c)){
                return true;
            }
        }

        seen[k] = false;
        result.Push(k);
        return false;
    
      }

    
        foreach(var key in graph.Keys){
            if(dfsSearch(key)){
                return "";
            }
        }

        return string.Join("",result);

    }
}
