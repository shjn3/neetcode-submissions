public class Solution {
    public int[] memo;
    public int Rob(int[] nums) {
        if(nums.Length==1) return nums[0];
        if(nums.Length==2) return Math.Max(nums[0],nums[1]);
        this.memo = new int[nums.Length];
        dfs(nums,0,0);
        int result =Math.Max(this.memo[^1],Math.Max(this.memo[^2],this.memo[^3]));
        // for(int i =0;i<this.memo.Length;i++){
        //     Console.WriteLine(" "+this.memo[i]);
        // }
        Array.Fill(this.memo,0);
        dfs(nums,1,0);
        int res2 = Math.Max(this.memo[^1],Math.Max(this.memo[^2],this.memo[^3]));
        return Math.Max(result,res2);
    }

    public void dfs(int[] nums ,int index, int cost){
        if(index>=nums.Length){
            return;
        }
        int nextCost = cost + nums[index];
        if(nextCost<this.memo[index]) return;
        this.memo[index] = nextCost;

        dfs(nums,index+2,nextCost);
        dfs(nums,index+3,nextCost);
    }
}
