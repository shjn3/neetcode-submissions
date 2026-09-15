public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length;
        
        int res = 0;
        int tank = 0;
        int total =0;

        for(int j =0;j<n;j++){
            int remain = gas[j]-cost[j];
            total+=remain;

            if(tank+remain<0){
                res =-1;
            }else{
                if(res==-1){
                    res = j;
                }
            }
            
            tank=Math.Max(0,tank+remain);
        }

        return total<0?-1: res;
    }
}
