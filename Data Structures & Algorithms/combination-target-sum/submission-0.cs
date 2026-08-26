public class Solution {
    List<List<int>> res = new();
    public List<List<int>> CombinationSum(int[] nums, int target) {
        BackTracking(new(),0,0,nums,target);
        return res;
    }

    public void BackTracking(List<int> arr, int total,int tempI, int[] nums,int target){
        if(total==target){
            res.Add(new List<int>(arr));
            return;
        }

        if(total>target){
            return;
        }
        for(int i =tempI;i<nums.Length;i++){
            arr.Add(nums[i]);
            BackTracking(arr,total+nums[i],i,nums,target);
            arr.RemoveAt(arr.Count-1);
        }
    }
}
