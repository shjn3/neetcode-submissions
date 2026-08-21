public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
      Stack<double> stack = new();
      int n = speed.Length;
      Array.Sort(position,speed);
      if(n==1) return 1;

      for(int i =n-1;i>=0;i--){
        double arriveTime =(double) (target-position[i])/speed[i];

        if(stack.Count==0 || stack.Peek()<arriveTime){
            stack.Push(arriveTime);
        }
        
      }

      return stack.Count;
    }

}
