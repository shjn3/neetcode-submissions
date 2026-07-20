public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> _map = new();
        for(int i =0;i<nums.Length;i++){
            if(!_map.ContainsKey(nums[i])){
                _map.Add(nums[i],0);
            }
            _map[nums[i]]+=1;
        }

        List<int>[] temp = new List<int>[nums.Length+1];

        foreach(var key in _map.Keys){
            int val = _map[key];
            if(temp[val]==null){
                temp[val] = new List<int>();
            }
            temp[val].Add(key);
        }

        int[] res = new int[k];
        int id = 0;
        for(int i = nums.Length;i>=0 && id<k;i--){
            List<int> arr =temp[i];
            if(arr==null) continue;
            foreach(var v in arr){
                res[id++]= v;
                if(id==k) break;
            }
            
        }

    
        return res;
    }
}
