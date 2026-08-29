public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length==0) return 0;
        if(nums.Length==1) return nums[0];
        int total =0;
        int n = nums.Length;
        int[] dp = new int[n];
        bool[] check = new bool[n];
        check[0] = true;
        check[1]= false;
        dp[0] = nums[0];
        dp[1]=nums[1];
        for(int i =2;i<n;i++){
            int num1,num2;
            num1 = dp[i-2]+nums[i];
            num2 = dp[i-1];
            if(num1>=num2){
                dp[i] = num1;
                check[i]=check[i-2];
            }else{
                dp[i]=num2;
                check[i] = check[i-1];
            }

            if(i==n-1 && check[i]){
                dp[i] = Math.Max(dp[i]-nums[0],dp[i]-nums[i]);
            }

            if(i>2){
                int num3 =nums[i]+dp[i-3];
                if(i==n-1 && check[i-3]){
                    num3 = Math.Max(num3-nums[0],num3-nums[i]);
                }

                if(num3>=dp[i]){
                    dp[i]=num3;
                    check[i]=check[i-3];
                }

            }
        }
        
        return Math.Max(dp[^1],dp[^2]);
    }
}
