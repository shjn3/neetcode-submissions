public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> _map = new();
        for(int i =0;i<nums.Length;i++){
            int key = nums[i];
            if(!_map.ContainsKey(key)){
                _map[key] = 0;
            }
            _map[key]+=1;
        }

        PriorityQueue<int,int> _q=  new();
        foreach(var _key in _map.Keys){
            _q.Enqueue(_key,_map[_key]*-1);
            // Console.WriteLine("Key: "+_key+" "+_map[_key]);
        }

        int[] res = new int[k];
        for(int i=0;i<k;i++){
            res[i] = _q.Dequeue();
        }


        return res;
    }
}
