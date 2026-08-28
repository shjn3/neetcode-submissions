public class Solution {
    List<List<string>>  res = new();
    public List<List<string>> Partition(string s) {
        BackTracking(s,"",0,new());
        return res;
    }

    public void BackTracking(string s,string t, int i,List<string> arr){
        if(i>=s.Length){

            int length = arr.Sum(a=>a.Length);
            if(length==s.Length){
                res.Add(new List<string>(arr));
            }
            return;
        }

        t+=s[i];
        if(isPalindrome(t)){
            arr.Add(t);
            BackTracking(s,string.Empty,i+1,arr);
            arr.Remove(t);
        }

        BackTracking(s,t,i+1,arr); 
    }

    private bool isPalindrome(string s){
        if(s.Length==1) return true;
        if(s.Length==0) return false;
        for(int i =0;i<s.Length/2;i++){
            if(s[i]!=s[s.Length-1-i]){
                return false;
            }
        }

        return true;
    }
}
