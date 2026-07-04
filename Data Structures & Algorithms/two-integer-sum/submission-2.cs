public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> _set = new();
        for(int i =0;i<nums.Length;i++){
          int remain = target - nums[i];
          if(_set.ContainsKey(remain)){
            return new int[]{_set[remain],i};
          }
          if(!_set.ContainsKey(nums[i])){
             _set.Add(nums[i],i);
          }
        }

        return new int[]{0,1};
    }
}
