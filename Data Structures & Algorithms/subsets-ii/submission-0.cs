public class Solution {
    List<List<int>> res = new();
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        BackTracking(new(),0,nums);

        return res;
    }

    public void BackTracking(List<int> arr,int i, int[] nums){
        if(i>=nums.Length){
            res.Add(new List<int>(arr));
            return;
        }

        int n =nums[i];
        arr.Add(n);
        BackTracking(arr,i+1,nums);
        arr.RemoveAt(arr.Count-1);
        while(i<nums.Length && nums[i]==n){
            i++;
        }
        BackTracking(arr,i,nums);
        
    }
}
