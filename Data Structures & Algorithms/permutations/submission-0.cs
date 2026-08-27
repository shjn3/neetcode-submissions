public class Solution {
    List<List<int>>  res = new();
    public List<List<int>> Permute(int[] nums) {
        BackTracking(new(),nums);
        return res;
    }

    public void BackTracking(List<int> arr, int[] nums){
        if(arr.Count>=nums.Length){
            res.Add(new List<int>(arr));
            return;
        }
        for(int i =0;i<nums.Length;i++){
            if(arr.Contains(nums[i])) continue;
            arr.Add(nums[i]);
            BackTracking(arr,nums);     
            arr.Remove(nums[i]);
        }
    }

}
