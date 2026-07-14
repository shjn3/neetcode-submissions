public class Solution {
    public int[] PlusOne(int[] digits) {
        int remainVal = 1;
        int[] newDigits = new int[digits.Length+1];
        for(int i =digits.Length-1;i>=0;i--){
            int nextVal = remainVal+digits[i];
            if(nextVal>=10){
                digits[i]=0;
                remainVal = nextVal/10;
            }else{
                remainVal =0;
                digits[i]=nextVal;
                newDigits[i+1]=nextVal;
                break;
            }
        }
        if(remainVal==0) return digits;

        newDigits[0]=remainVal;
        return newDigits;
    }
}
