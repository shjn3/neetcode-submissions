public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] products1 = new int[nums.Length];
        int[] products2 = new int[nums.Length];
        int[] products = new int[nums.Length];

    
        int n = nums.Length;
        products1[0] = nums[0];
        products2[0] = nums[n-1];

        for(int i =1;i<n;i++){
            int factor = nums[i];
            products1[i]=products1[i-1]*factor;
            products2[i]=products2[i-1]*nums[n-1-i];
        }

        for(int i =0;i<n;i++){
            if(i==0){
                products[i] = products2[n-2];
                continue;
            }

            if(i==n-1){
                 products[i] = products1[n-2];
                 continue;
            }

            products[i] = products1[i-1]*products2[n-1-i-1];
        }
        

        return products;
    }
}
