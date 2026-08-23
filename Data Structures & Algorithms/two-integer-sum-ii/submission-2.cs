public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int n = numbers.Length;
        int p1 = 0;
        int p2 = n-1;
        while(p1<=p2){
            if(p1==p2) break;
            int res = numbers[p1]+numbers[p2];

            if(res<target){
                p1++;
            }
            else if(res>target){
                p2--;
            }else{
                return new int[]{p1+1,p2+1};
            }
        }
      

        return new int[0];
    }
}
