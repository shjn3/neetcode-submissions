public class Solution {

     public int LongestConsecutive(int[] nums) {
        HashSet<int> _set  =new (nums);
        int longest = 0;

        for(int i =0;i<nums.Length;i++){
            if(!_set.Contains(nums[i]-1)){
                int length = 0;
                int start = nums[i];
                while(_set.Contains(start)){
                    length++;
                    start++;
                }

                longest = Math.Max(longest,length);
            }
        }
        return longest;
    }
}
