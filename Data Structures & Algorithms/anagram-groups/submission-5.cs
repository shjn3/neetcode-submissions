public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> result = new();

        Dictionary<string, List<string>> _dictResult =new();

        for(int i =0;i<strs.Length;i++){
            string sortedStr = string.Concat(strs[i].OrderBy(c=>c));
            _dictResult.TryAdd(sortedStr, new());
            _dictResult[sortedStr].Add(strs[i]);
        }

        foreach(var arr in _dictResult.Values){
            result.Add(arr);
        }

        return result;
    }
}
