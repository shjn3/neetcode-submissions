public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] amounts = new int[n];
        int left = 0;
        int right = n-1;
        int prevLeft=left;
        int prevRight =right;
        while(left<=right){
            int leftHeight = height[left];
            int rightHeight = height[right];
            int minHeight = Math.Min(leftHeight,rightHeight);
            for(int i =left+1;i<right;i++){
                amounts[i] = Math.Max(amounts[i], minHeight-height[i]);
            }

            if(height[left]<height[right]){
                while(left<=right && height[left]<=leftHeight){
                    left++;
                }
            }else{
                while(left<=right && height[right]<=rightHeight){
                   right--;
                }
            }
        }
        int t = 0;
        int temp =0;
        while(t<n){
            if(amounts[t]>0){
                temp+=amounts[t];
            }
            t++;
        }

        return temp;    
    }
}
