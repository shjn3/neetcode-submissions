public class Solution {  
    List<string> res = new();
    public List<string> GenerateParenthesis(int n) {
       BackTracking("",n,n);
       return res;
    }

    void BackTracking(string r, int openCount, int closeCount){
        if(openCount==0 && closeCount==0){
            res.Add( new string(r));
            return;
        }

        if(openCount>0){
            r+="(";
            BackTracking(r,openCount-1,closeCount);
            r=r.Remove(r.Length-1,1);
        }
 
        if(openCount==closeCount){
            return;
        }
        r+=")";
        BackTracking(r,openCount,closeCount-1);
        r= r.Remove(r.Length-1);

    }
}
