public class Solution {
    int[] memo;
    public int NumDecodings(string s) {
        if(s[0]=='0') return 0;
        if(s.Length==1) return 1;
        this.memo = new int[s.Length];
        dfs(s,0);

        return this.memo[0];
    }

    public int dfs(string s ,int index){
        if(index>=s.Length)
            return 1;
        if(s[index]=='0') return 0;
        if(this.memo[index]!=0) return this.memo[index];

        this.memo[index]+= dfs(s,index+1);

        if(index<s.Length-1){
            int res2 = int.Parse($"{s[index]}{s[index+1]}");
            if(res2<=26) {
                this.memo[index]+= dfs(s,index+2);
            }
        }

        return this.memo[index];
 }
}
