public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> _set =new();
        for(int i =0;i<nums.Length;i++){
            if(_set.Contains(nums[i])) return true;
            _set.Add(nums[i]);
        }

        return false;
    }
}