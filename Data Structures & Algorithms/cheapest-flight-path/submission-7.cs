public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] prices =new int[n];
        Array.Fill(prices,int.MaxValue);
        prices[src]=0;

        for(int  i=0;i<=k;i++){
            int[] temp = (int[])prices.Clone();
            foreach(var flight in flights){
                var fS =flight[0];
                var fD =flight[1];
                var fP = flight[2];
                if(prices[fS]==int.MaxValue) continue;

                if(prices[fS] + fP<temp[fD]){
                    temp[fD] = prices[fS]+fP;
                }
            }
            prices = temp;
        }

        return prices[dst]==int.MaxValue?-1:prices[dst];
   
    }
}
