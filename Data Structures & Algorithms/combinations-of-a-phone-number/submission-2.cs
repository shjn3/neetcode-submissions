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
      BackTracking(digits,0,"");
      return res;   
    }
    public void BackTracking(string digits, int i, string v){
        if(v.Length==digits.Length){
            res.Add(v);
            return;
        }
        int number = int.Parse(digits.Substring(i,1));
        foreach(var c in characters[number]){
             v+=(char)c;
            BackTracking(digits,i+1,v);
            v = v.Remove(v.Length-1);
        }


    }
}
