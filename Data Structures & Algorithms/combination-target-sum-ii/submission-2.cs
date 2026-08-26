public class Solution {
    List<List<int>> res = new();
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        BackTracking(candidates,target, new(),0,0);
        return res;
    }

    private void BackTracking(int[] candidates, int target, List<int> arr, int idx, int total){
        if(idx>=candidates.Length){
            if(total==target && arr.Count>0){
                res.Add(new List<int>(arr));
            }
            return;
        }
        if(total>target) return;
        if((arr.Count==0  && idx>0&& candidates[idx]==candidates[idx-1])){
            BackTracking(candidates,target, arr,idx+1,total);
            return;
        }


        int num = candidates[idx];
        total+=num;
        arr.Add(num);
        BackTracking(candidates, target, arr, idx+1, total);
        total-=num;
        while(idx<candidates.Length && candidates[idx]==num){
            idx++;
        }
        arr.RemoveAt(arr.Count-1);
        BackTracking(candidates, target, arr, idx, total);
    }
}
