public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length!=t.Length) return false;
        
        Dictionary<char,int>  _dict = new();
        for(int i =0;i<s.Length;i++){
            _dict.TryAdd(s[i],0);
            _dict[s[i]]+=1;
        }

        for(int i =0;i<t.Length;i++){
            if(!_dict.ContainsKey(t[i]) || _dict[t[i]]==0) return false;
            _dict[t[i]]-=1;
        }

        return true;
    }
}
