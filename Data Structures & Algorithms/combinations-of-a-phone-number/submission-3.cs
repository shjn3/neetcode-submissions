public class Solution {
    List<string> res = new();
    public string[] characters = new string[]{
        "",
        "",
        "abc",
        "def",
        "ghi",
        "jkl",
        "mno",
        "pqrs",
        "tuv",
        "wxyz"
    };
    public List<string> LetterCombinations(string digits) {
      if(digits.Length==0) return new List<string>();
      BackTracking(digits,0,0,"");
      return res;   
    }
    public void BackTracking(string digits, int i,int subId, string v){
        if(v.Length==digits.Length){
            res.Add(v);
            return;
        }
        int number = int.Parse(digits.Substring(i,1));

        if(subId>=characters[number].Length) {
            return;
        }

        v+=(char)characters[number][subId];
        BackTracking(digits,i+1,0,v);
        v = v.Remove(v.Length-1);
        BackTracking(digits,i,subId+1,v);
    }
}
