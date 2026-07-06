public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> result = new();
        List<(string,string)> cloneArr = new List<(string,string)>();
        for(int i =0;i<strs.Length;i++){
            cloneArr.Add((strs[i],string.Concat(strs[i].OrderBy(c=>c))));
        }

        while(cloneArr.Count>0){
            var item1 = cloneArr[0];
            List<string> toRemove  =new List<string>(){
               item1.Item1
            };

            List<(string,string)> nextArr = new();
            for(int i =1;i<cloneArr.Count;i++){

                if(this.isAnagram(item1.Item2,cloneArr[i].Item2)){
                    toRemove.Add(cloneArr[i].Item1);
                }else{
                    nextArr.Add(cloneArr[i]);
                }
            }

            cloneArr = nextArr;
            result.Add(toRemove);
        }

        return result;
    }

    public bool isAnagram(string sortS1, string sortS2){
        if(sortS1.Length!=sortS2.Length) return false;
        for(int i =0;i<sortS1.Length;i++){
            if(sortS1[i]!=sortS2[i]) return false;
        }
       return true;
    }
}
