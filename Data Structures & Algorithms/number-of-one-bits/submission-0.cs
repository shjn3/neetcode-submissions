public class Solution {
    public int HammingWeight(uint n) {
        int bitCount= sizeof(int)*8;
        uint count =0;
        for(int i =0;i<bitCount;i++){
            uint digit = n&1;
            count+=digit;
            n=n>>1;
        }

        return (int)count;
    }
}
