public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length;

        int res = 0;
        int tank = 0;
        int total =0;

        for(int j =0;j<n;j++){
            int remain = gas[j]-cost[j];
            total+=remain;
            tank+=remain;

            if(tank<0){
                res =-1;
                tank =0;
            }else{
                res = res==-1?j:res;
            }
        }

        return total<0?-1: res;
    }
}
