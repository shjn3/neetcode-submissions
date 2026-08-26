public class Solution {
    List<List<int>> res =new();
    public List<List<int>> Subsets(int[] nums) {
        dfs(0,nums,new List<int>(nums.Length));

        return res;
    }

    public void dfs(int i,int[] nums,List<int> arr){
        res.Add(new List<int>(arr));
        for(int j=i;j<nums.Length;j++){
            arr.Add(nums[j]);
            dfs(j+1,nums,arr);
            arr.RemoveAt(arr.Count-1);
        }
    }
}
