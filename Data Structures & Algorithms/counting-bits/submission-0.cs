public class Solution {
    public int[] CountBits(int n) {
        int[] ans = new int[n+1];
        for(int i =0;i<=n;i++){
            int bits = CountBit(i);
            ans[i] = bits;

        }
        return ans;
    }

    public int CountBit(int n){
        if(n==0) return 0;
        if(n==1) return 1;
        
        int c =0;
        for(int i =0;i<32;i++){
            int nums = n &(1<<i);
            if(nums!=0){
                c+=1;
            }
        }

        return c;
    }
}
