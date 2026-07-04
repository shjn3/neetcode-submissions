public class Solution {
    public bool CanJump(int[] nums) {
        int[] memo = new int[nums.Length];

        memo[^1]= nums.Length-1;

        for(int i =nums.Length-2;i>=0;i--){
            int jump=nums[i];
            
            memo[i] = i+jump>=memo[i+1]?i:memo[i+1];
        }

        for(int i=0;i<nums.Length;i++){
            Console.WriteLine("i: "+memo[i]);
        }

        return memo[0] ==0;


    }
}
