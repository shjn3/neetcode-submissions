public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new();
        List<Tuple<int,int>>  newNums = new();
        int n = nums.Length;
        for(int i =0;i<n;i++){
            newNums.Add(new Tuple<int,int>(nums[i],i));
        }

        newNums.Sort((a,b)=>a.Item1.CompareTo(b.Item1));

        int l =0;
        int r = n-1;
        while(l<=r){

            int left = l;
            int right = r;
        //    Console.WriteLine("Left-right: "+l+" "+r);
            while(left<=right){
                var item1 = newNums[left];
                var item2 = newNums[right];
                // if(Math.Sign(item1.Item1)== Math.Sign(item2.Item2)) break;
                int remain = -(item2.Item1+item1.Item1);
                // Console.WriteLine("lllLeft-righttt: "+left+" "+right);
                if(remain<item1.Item1 || remain>item2.Item1){
                    left++;
                    continue;
                }

                int findId = -1;
                int temp1 = left+1;
                int temp2 = right-1;
                while(temp1<=temp2){
                    int mid = (int)(temp1+(temp2-temp1)*0.5f);
                    if(newNums[mid].Item1==remain){
                        findId = mid;
                        break;
                    }
                    if(newNums[mid].Item1>remain){
                        temp2=mid-1;
                    }
                    else{
                        temp1=mid+1;
                    }
                }
                if(findId!=-1){
                    result.Add(new List<int>(){
                    newNums[left].Item1,newNums[findId].Item1,newNums[right].Item1
                    });
                }
                int previousVal = newNums[left].Item1;
                while(left<=right && newNums[left].Item1== previousVal) left++;
            }
            int rightPreviousVal = newNums[r].Item1;
            while(l<=r && rightPreviousVal== newNums[r].Item1) r--;
        }

        return result;
    }
}
