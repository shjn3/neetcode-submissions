public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] products = new int[nums.Length];
        Array.Fill(products,1);
        int n =nums.Length;
        for(int i =0;i<n;i++){
            int factor = nums[i];
            if(factor==1) continue;
            for(int j=0;j<n;j++){
                if(j==i) continue;
                products[j]*=factor;
            }
            if(factor==0) {
                for(int k =i+1;k<n;k++){
                    products[i]*=nums[k];
                    if(nums[k]==0) break;
                }

                break;
            }
        }

        return products;
    }
}
