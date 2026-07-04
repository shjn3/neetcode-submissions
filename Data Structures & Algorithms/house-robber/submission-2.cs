public class Solution {
    public int[] memo;
    public int Rob(int[] nums) {
        if(nums.Length==1) return nums[0];
        if(nums.Length==2) return Math.Max(nums[0],nums[1]);
        this.memo = new int[nums.Length];
        this.memo[0] = nums[^1];
        int n = nums.Length;
        for(int i =n-1;i>=0;i--){
            int memoIdx = n-1-i;
            if(memoIdx+2<n){
                this.memo[memoIdx+2]=Math.Max(this.memo[memoIdx+2], this.memo[memoIdx]+nums[i-2]);
            }
            if(memoIdx+3<n){
                this.memo[memoIdx+3]=Math.Max(this.memo[memoIdx+3], this.memo[memoIdx]+nums[i-3]);
            }
        }
        int result = Math.Max(this.memo[^1],this.memo[^2]);

        Array.Fill(this.memo,0);

        this.memo[1] = nums[^2];
        for(int i =n-2;i>=0;i--){
            int memoIdx = n-1-i;
            if(memoIdx+2<n){
                this.memo[memoIdx+2]=Math.Max(this.memo[memoIdx+2], this.memo[memoIdx]+nums[i-2]);
            }
            if(memoIdx+3<n){
                this.memo[memoIdx+3]=Math.Max(this.memo[memoIdx+3], this.memo[memoIdx]+nums[i-3]);
            }
        }

        return Math.Max(result,Math.Max(this.memo[^1],this.memo[^2]));
    }
}
