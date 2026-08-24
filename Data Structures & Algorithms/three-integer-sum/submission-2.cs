public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new();
        List<Tuple<int,int>>  newNums = new();
        int n = nums.Length;
        for(int m =0;m<n;m++){
            newNums.Add(new Tuple<int,int>(nums[m],m));
        }

        newNums.Sort((a,b)=>a.Item1.CompareTo(b.Item1));
        int i = 0;
        while(i<n-2){
            int j = i+1;
            int k = n-1;
            int target = -newNums[i].Item1;
            while(j<k){
                int sum = newNums[j].Item1+newNums[k].Item1;
                if(sum==target){
                    result.Add(new List<int>(){
                        newNums[i].Item1,newNums[j].Item1,newNums[k].Item1
                    });

                    int previousJ = newNums[j].Item1;
                    int previousK = newNums[k].Item1;
                    while(j<k && newNums[j].Item1==previousJ){
                        j++;
                    }

                    while(j<k && newNums[k].Item1==previousK) {
                        k--;
                    }
                    
                    continue;
                }

                if(sum<target){
                    j++;
                }else{
                    k--;
                }
            }

            while(i<n-2 && newNums[i].Item1== -target)
            i++;
        }


        return result;
    }
}
