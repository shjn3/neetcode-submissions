public class Solution {
    public int MaxProduct(int[] nums) {
        if(nums.Length==1){
            return nums[0];
        }
        int min = nums[0];
        int max = nums[0];
        int res =int.MinValue;

        for(int i=1;i<nums.Length;i++){
            int num =nums[i];
            int num1= max*num;
            int num2 =min*num;

            max = Math.Max(num1,num);
            min = Math.Min(num2,num);

            if(num<0 && num2>num1){
                max = Math.Max(max,num2);
                min = Math.Min(min,num1);
            }

            res = Math.Max(max,res);
        }

        return res;
    }
}
