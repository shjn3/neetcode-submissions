public class Solution {
    public int[] PlusOne(int[] digits) {
        int remainVal = 1;
        bool isUseNewArr = digits[0]==9;
        int[] newDigits = new int[isUseNewArr?digits.Length+1:0];
        for(int i =digits.Length-1;i>=0;i--){
            int nextVal = remainVal+digits[i];
            if(nextVal>=10){
                digits[i]=0;
                remainVal = 1;
            }else{
                remainVal =0;
                digits[i]=nextVal;
                if(isUseNewArr) newDigits[i+1]=nextVal;
                break;
            }
        }
        if(remainVal==0) return digits;

        newDigits[0]=remainVal;
        return newDigits;
    }
}
