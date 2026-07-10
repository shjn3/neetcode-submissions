public class Solution {
    public int MaxProfit(int[] prices) {
        int max =0;
        int length = prices.Length;
        for(int i =0;i<length-1;i++){
            
            for(int j =i+1;j<length;j++){
                max =Math.Max(max, prices[j]-prices[i]);
            }
        }

        return max;
    }
}
