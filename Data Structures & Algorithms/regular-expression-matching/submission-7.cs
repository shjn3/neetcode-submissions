public class Solution {

    public bool IsMatch(string s, string p) {
        int n = p.Length;
        string t = filter(p);
        // Console.WriteLine("t: "+t);
        return dfs(s,filter(p),0,0);
    }

    public string filter (string p){
        int n =p.Length;
        List<char> res=  new();
        int i =0;
        char[] letters = p.ToCharArray();
        char previous ='*';
        while(i<n){
            if(i<n-1&&letters[i+1]=='*'){
                if(previous!='.'&&letters[i]!=previous){
                    res.Add(letters[i]);
                    res.Add(letters[i+1]);
                    previous = letters[i];
                }
                i+=2;
                continue;
            }
            res.Add(letters[i]);
            previous='*';
            i++; 
        }

        return new string(res.ToArray());
    }

    public bool isEmpty(string a, int from){
        int n =a.Length;
        while(from<n-1){
            if(a[from+1]=='*'){
                from+=2;
            }else{
                return false;
            }
        }
        return from==n;
    }

    public bool dfs(string s, string p, int i1, int i2){
        if(i1==s.Length && i2==p.Length) return true;
        if(i1==s.Length){
            return isEmpty(p,i2);
        }

        if(i2==p.Length) return false;

        if(i2<p.Length-1 && p[i2+1]=='*'){
            return dfs(s,p,i1,i2+1);
        }

        if(p[i2]!='*'){
            if(p[i2]==s[i1] || p[i2]=='.'){
               return dfs(s,p,i1+1,i2+1);
            }
        }else{
            if(p[i2-1]==s[i1] || p[i2-1]=='.'){
                if(dfs(s,p,i1+1,i2) || dfs(s,p,i1+1,i2+1)){
                    return true;
                }
            }
            return  dfs(s,p,i1,i2+1);
        }
    
        return false;
    }
}
