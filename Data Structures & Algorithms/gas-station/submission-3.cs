public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int n = gas.Length;
        int s1 = 0;
        int s2 =0;

        for(int i =0;i<n;i++){
            s1+=gas[i];
            s2+=cost[i];
        }
        if(s1<s2) return -1;
        int res = 0;
        int tank = 0;

        for(int j =0;j<n;j++){
            int remain = gas[j]-cost[j];

            if(tank+remain<0){
                res =-1;
            }else{
                if(res==-1){
                    res = j;
                }
            }
            
            tank=Math.Max(0,tank+remain);
        }

        return res;
    }
}
