public class Solution {
    public uint ReverseBits(uint n) {
        uint res=0;
        for(int i=32;i>=0;i--){
            res=res|(((n>>(32-i))&1)<<(i-1));
        }

        return res;
    }
}
