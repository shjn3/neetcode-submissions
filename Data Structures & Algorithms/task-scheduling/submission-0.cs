public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach(var task in tasks){
            count[task-'A'] +=1;
        }
        Array.Sort(count);
        int maxf = count[25];
        int idle = (maxf-1)*n;

        for(int i =24;i>=0;i--){
            idle-=Math.Min(maxf-1,count[i]);
        }

        return Math.Max(0,idle)+tasks.Length;

    }
}
