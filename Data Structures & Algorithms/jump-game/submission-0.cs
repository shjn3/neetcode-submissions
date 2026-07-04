public class Solution {

    public bool isValid = false;
    public bool CanJump(int[] nums) {
        dfs(nums,0);
        return isValid;
    }

    public void dfs(int[] nums, int index){
        if(index>=nums.Length-1 || this.isValid || index+nums[index]>=nums.Length-1){
            this.isValid= true;
            return;
        }

        for(int i =1;i<=nums[index];i++){
            dfs(nums, index+i);
            if(this.isValid) return;
        }
    }
}
