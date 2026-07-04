public class Solution {

    public int NumDecodings(string s) {
        if(s[0]=='0') return 0;
        if(s.Length==1) return 1;

        int[] memo = new int[s.Length];
        if(s[^1]!='0'){
            memo[^1]=1;
        }

        if(s[^2]!='0'){
            memo[^2]=memo[^1];
            if(isValid(s[^2],s[^1])){
                memo[^2]+=1;
            }
        }
        
        for(int i =s.Length-3;i>=0;i--){
            if(s[i]=='0') continue;
            memo[i] = memo[i+1];
            if(isValid(s[i],s[i+1])){
               memo[i]+=memo[i+2];
            }

            if(memo[i]==0) return 0;
        }

        return memo[0];
    }

    public bool isValid(char s1, char s2){
        if(s1=='0'||s1>'2') return false;
        if(s1=='2' && s2>'6') return false;
        return true;
    }


}
