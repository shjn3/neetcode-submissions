public class Solution {
    int[,] dp;
    public int LongestCommonSubsequence(string text1, string text2) {
        int n1=text1.Length;
        int n2 = text2.Length;
        int res=0;
        if(dp==null){
            dp = new int[n1,n2];
            for(int i =0;i<n1;i++){
                for(int j=0;j<n2;j++){
                    dp[i,j]=int.MaxValue;
                }
            }
        }
        
        for(int i =0;i<n1;i++){
            for(int j=0;j<n2;j++){
                if(text1[i]==text2[j]){
                    // int next =1;
                    // if(i==n1-1 || j==n2-1){}
                    // else{
                    // next+=LongestCommonSubsequence(
                    //         text1.Substring(i+1),
                    //         text2.Substring(j+1)
                    //         );
                    // }
                    int l =n1-i-1;
                    int l1= n2-j-1;
                    if(dp[l,l1]==int.MaxValue){
                        if(i==n1-1 || j==n2-1){
                            dp[l,l1]=1;
                        }else{
                            dp[l,l1] =1+LongestCommonSubsequence(
                                text1.Substring(i+1),
                                text2.Substring(j+1)
                                );
                        }
                    }

                    // if(res<8 && dp[i,j]==8){
                    //     Console.WriteLine(": "+i+" "+j+" "+text1+" "+text2);
                    // }
                    
                    // res = Math.Max(next,res);
                    res = Math.Max(dp[l,l1],res);
                   
                }
            }
        }


        return res;
    }
}
