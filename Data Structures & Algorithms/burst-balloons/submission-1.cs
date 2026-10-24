public class Solution {
    int[,] dp;
    public int MaxCoins(int[] nums) {
        int n =nums.Length;
        int[] newNums = new int[n+2];
        newNums[0] =1;
        newNums[n+1]=1;
        for(int i =0;i<n;i++){
            newNums[i+1]=nums[i];
        }
        dp = new int [n+2,n+2];
        for(int i=0;i<=n;i++){
            for(int j=0;j<=n;j++){
                dp[i,j]=-1;
            }
        }

        return dfs(newNums,1,n);
    }

    public int dfs(int[] nums, int l, int r){
        if(l>r) return 0;
        if(dp[l,r]!=-1) return dp[l,r];
        dp[l,r]=0;
        for(int i=l;i<=r;i++){
            var coin = nums[i]*nums[l-1]*nums[r+1];
            coin+=dfs(nums,l,i-1)+dfs(nums,i+1,r);

            dp[l,r] =Math.Max(dp[l,r],coin);
        }

        return dp[l,r];
    }
}
