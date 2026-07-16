public class Solution {
    public int MissingNumber(int[] nums) {
        if(nums.Length==0) return 0;
        int n=0;
        bool hasZero = false;
        int max = int.MinValue;
        foreach(var num in nums){
            n^=num;
            max = Math.Max(max,num);
            if(num==0) {
                hasZero = true;
            }
        }

        for(int i = 0;i<=max;i++){
            n^=i;
        }
        if(hasZero && n==0){
            return max+1;
        }

        return n;
    }
}
