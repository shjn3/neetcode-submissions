public class Solution {
    int[,] dp;

    public bool IsInterleave(string s1, string s2, string s3) {    
        int n = s1.Length;
        int m = s2.Length;
        if(s3.Length!=n+m) return false;
        if(s3==s1+s2) return true;
        if(n==0 || m==0){
            return false;
        }
        bool isCreateDP = false;
        if(dp==null){
          dp = new int[n,m];
          isCreateDP = true;
        }

        for(int i =0;i<n;i++){
            string sub1 = s1.Substring(0,i+1);
            if(sub1!=s3.Substring(0,i+1)) continue;
            string remain  =s3.Substring(i+1);
            bool res =false;
            for(int j=0;j<m;j++){
                string sub2 = s2.Substring(0,j+1);
                 if(sub2!=remain.Substring(0,j+1)) continue;
                 
                 if(dp[i,j]==0){
                    var temp = res = IsInterleave(s1.Substring(i+1),s2.Substring(j+1),remain.Substring(j+1));
                    dp[i,j] = temp?1:2;
                 }

                 res = dp[i,j]==1;
            }

            if(res) return true;
        }
        string t =s1;
        s1=s2;
        s2 =t;
        n = s1.Length;
        m = s2.Length;

        if(isCreateDP){
            dp = new int[n,m];
        }


        for(int i =0;i<n;i++){
            string sub1 = s1.Substring(0,i+1);
            if(sub1!=s3.Substring(0,i+1)) continue;
            string remain  =s3.Substring(i+1);
            bool res =false;
            for(int j=0;j<m;j++){
                string sub2 = s2.Substring(0,j+1);
                 if(sub2!=remain.Substring(0,j+1)) continue;
                 
                 if(dp[i,j]==0){
                    var temp = res = IsInterleave(s1.Substring(i+1),s2.Substring(j+1),remain.Substring(j+1));
                    dp[i,j] = temp?1:2;
                 }

                 res = dp[i,j]==1;
            }

            if(res) return true;
        }

    
        return false;
    }
}
