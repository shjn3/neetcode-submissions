public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> result = new();
        List<string> cloneArr = new List<string>(strs);

        List<string> nextArr = new();
        while(cloneArr.Count>0){
            string pattern  = cloneArr[0];
            string sortPattern = string.Concat(pattern.OrderBy(c=>c));
            List<string> toRemove  =new List<string>(){
                pattern
            };

            for(int i =1;i<cloneArr.Count;i++){
                if(this.isAnagram(sortPattern,cloneArr[i])){
                    toRemove.Add(cloneArr[i]);
                }else{
                    nextArr.Add(cloneArr[i]);
                }
            }

            // cloneArr = cloneArr.Where(_s=>!toRemove.Contains(_s)).ToList();
            var temp = cloneArr;
            cloneArr = nextArr;
            nextArr= temp;
            nextArr.Clear();

            result.Add(toRemove);
        }

        return result;
    }

    public bool isAnagram(string sortS1, string s2){
        if(sortS1.Length!=s2.Length) return false;
        string sortS2 = string.Concat(s2.OrderBy(c=>c));
        for(int i =0;i<sortS1.Length;i++){
            if(sortS1[i]!=sortS2[i]) return false;
        }

       return true;
    }
}
