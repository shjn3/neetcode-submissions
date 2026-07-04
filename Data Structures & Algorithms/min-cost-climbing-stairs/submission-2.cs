public class Solution {
    public int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        this.memo = new int[n+2];
        Array.Fill(this.memo,int.MaxValue);
        this.memo[0]=0;
        for(int i =n-1;i>=0;i--){
            int idx = n-1-i;
            int _c = cost[i]+this.memo[idx];
            this.memo[idx+1]= Math.Min(this.memo[idx+1],_c);
            this.memo[idx+2]= Math.Min(this.memo[idx+2],_c);
        }
        //  Console.WriteLine("Memeo: ");
        // for(int i =0;i<n+2;i++){
        //     Console.WriteLine(" "+this.memo[i]);
        // }

        int result = Math.Min(this.memo[^1],this.memo[^2]);
        Array.Fill(this.memo,int.MaxValue);
        this.memo[1]=0;
        for(int i =n-2;i>=0;i--){
            int idx = n-1-i;
            int _c = cost[i]+this.memo[idx];
            this.memo[idx+1]= Math.Min(this.memo[idx+1],_c);
            this.memo[idx+2]= Math.Min(this.memo[idx+2],_c);
        }
    // Console.WriteLine("Memeo: ");
    //     for(int i =0;i<n+2;i++){
    //         Console.WriteLine(" "+this.memo[i]);
    //     }


        return Math.Min(result,Math.Min(this.memo[^1],this.memo[^2]));
    }
}
