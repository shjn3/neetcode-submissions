public class Solution {
    int target =-1;
    int[,] arr;
    public bool CanPartition(int[] nums) {
        int total = nums.Sum();
        if(total%2!=0) return false;
        target =total/2;
        int n = nums.Length;
        arr = new int[n,target];

        return dfs(nums,0,0);
    }

    public bool dfs(int[] nums, int curSum,int i){
        if(curSum==target) return true;
 
        if(curSum>target || i>=nums.Length){
            return false;
        }
        if(arr[i,curSum]!=0){
            return arr[i,curSum]==1;
        }
        arr[i,curSum] = (dfs(nums,curSum+nums[i],i+1)|| dfs(nums,curSum,i+1))?1:2; 
        return arr[i,curSum]==1;
    }
}
