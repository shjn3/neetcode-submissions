public class Solution {
    public int MissingNumber(int[] nums) {
        if(nums.Length==0) return 0;
        int res  =0;
        int min =int.MaxValue;
        int max =int.MinValue;
        bool hasZero= false;
        for(int i =0;i<nums.Length;i++){
            res+=nums[i];
            min = Math.Min(min,nums[i]);
            max = Math.Max(max,nums[i]);
            if(nums[i]==0){
                hasZero = true;
            }
        }
        int x = min;
        int y= max;
        int total = (x+y)*(y-x+1)/2;
        if(total-res==0){
            if(hasZero){
                return max+1;
            }
            return 0;
        }
        return total-res;
    }
}
