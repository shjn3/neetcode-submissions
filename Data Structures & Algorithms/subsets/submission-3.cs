public class Solution {
    List<List<int>> res =new();
    public List<List<int>> Subsets(int[] nums) {
        dfs(0,nums,new List<int>(nums.Length));

        return res;
    }

    public void dfs(int i,int[] nums,List<int> arr){
      if(i>=nums.Length){
        res.Add(new List<int>(arr));
        return;
      }
      dfs(i+1,nums,arr);
      arr.Add(nums[i]);
      dfs(i+1,nums,arr);
      arr.RemoveAt(arr.Count-1);
    }
}
