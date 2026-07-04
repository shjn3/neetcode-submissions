public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,List<int>> _set = new();
        for(int i =0;i<nums.Length;i++){
          _set.TryAdd(nums[i],new ());
          int remain = target - nums[i];
          if(_set.ContainsKey(remain) && _set[remain].Count>0){
            return new int[]{_set[remain][0],i};
          }

           _set[nums[i]].Add(i);
        }

        return new int[]{0,1};
    }
}
