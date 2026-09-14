public class Solution {
    public int Jump(int[] nums) {
        int count =0;
        int cursor = 0;
        int n =nums.Length;
        if(n==1) return 0;
        while(cursor<n-1){
            if(cursor+nums[cursor]>=n-1) {
                count++;
                break;
            }
            int maxId = cursor+1;
            for(int j = cursor+1;j<n&&j<=cursor+nums[cursor];j++){
                if(maxId+nums[maxId]<=j+nums[j]){
                    maxId = j;
                }
            }

            cursor = maxId;
            count++;
        }
        return count;
    }
}
