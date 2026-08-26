public class Solution {
    List<List<int>> res = new();
    public List<List<int>> CombinationSum(int[] nums, int target) {
        BackTracking(new(),0,0,nums,target);
        return res;
    }

    public void BackTracking(List<int> arr, int total,int i, int[] nums,int target){
        if(i>=nums.Length){
            if(total==target && arr.Count>0){
                res.Add(new List<int>(arr));
            }

            return;
        }

        if(total>target){
            return;
        }
        int num = nums[i];
        total+=num;
        arr.Add(num);
        BackTracking(arr,total,i,nums,target);
        total-=num;
        arr.RemoveAt(arr.Count-1);
        BackTracking(arr,total,i+1,nums,target);

    }
}
