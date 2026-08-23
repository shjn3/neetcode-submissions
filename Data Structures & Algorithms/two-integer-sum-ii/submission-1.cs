public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int n = numbers.Length;
        int[] res = new int[n];
        int left =0;
        while(left<n){
            int remain = target - numbers[left];
            int resultId = -1;

            int l1 = left+1;
            int r = n-1;
            while(l1<=r){
                int mid = (int)(l1+(r-l1)*0.5f);
                int number = numbers[mid];
                if(number==remain){
                    while(mid+1<=r && numbers[mid+1]==remain){
                        mid++;
                    }
                    resultId = mid;
                    break;
                }
                if(number<remain){
                    l1 = mid+1;
                }
                else{
                    r=mid-1;
                }
            }

            if(resultId!=-1){
                return new int[]{
                    left+1,resultId+1
                };
            }
            left++;
        }
        
        return res;
    }
}
