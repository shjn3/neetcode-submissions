public class Solution {
    public int[] PlusOne(int[] digits) {
        int remainVal = 1;
        for(int i =digits.Length-1;i>=0;i--){
            if(remainVal==0) break;
            int nextVal = remainVal+digits[i];
            if(nextVal>=10){
                digits[i]=0;
                remainVal = nextVal/10;
            }else{
                remainVal =0;
                digits[i]=nextVal;
            }
        }

        if(remainVal >0){
        
            Array.Resize(ref digits, digits.Length+1);
            for(int i=digits.Length-1;i>=1;i--){
                digits[i]=digits[i-1];
            }
            digits[0]=remainVal;
            return digits;
        }

        return digits;
    }
}
