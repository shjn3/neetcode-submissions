public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<string> cloneArr = new List<string>(strs);
        List<List<string>> result = new();
        while(cloneArr.Count>0){
            string pattern  = cloneArr[0];
            List<string> toRemove  =new List<string>(){
                pattern
            };

            for(int i =1;i<cloneArr.Count;i++){
                if(this.isAnagram(pattern,cloneArr[i])){
                    toRemove.Add(cloneArr[i]);
                }
            }

            cloneArr = cloneArr.Where(_s=>!toRemove.Contains(_s)).ToList();
            result.Add(toRemove);
        }

        return result;
    }

    public bool isAnagram(string s1, string s2){
        if(s1.Length!=s2.Length) return false;
       Dictionary<char, int> _dict  = new();
       foreach(var c in s1){
            _dict.TryAdd(c,0);
            _dict[c]+=1;
       }

       foreach(var c in s2){
            if(!_dict.ContainsKey(c)) return false;
            _dict[c]-=1;
            if(_dict[c]<0) return false;
       }

       return true;
    }
}
