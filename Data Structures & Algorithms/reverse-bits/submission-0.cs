public class Solution {
    public uint ReverseBits(uint n) {
        uint res=0;
        for(int i=32;i>=0;i--){
            uint digit = (n>>(32-i))&1;
            if(digit==0) continue;
            digit = digit<<(i-1);
            res=res|digit;
        }

        return res;
    }
}
