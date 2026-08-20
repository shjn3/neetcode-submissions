public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        if(n==1) return new int[]{0};
        int[] results = new int[n];
        Stack<int> _stack = new();
        for(int i=n-1;i>=0;i--){
            while(_stack.Count>0 && temperatures[_stack.Peek()]<=temperatures[i]){
                _stack.Pop();
            }

            if(_stack.Count==0){
                _stack.Push(i);
                continue;
            }

            results[i] = _stack.Peek()-i;
            _stack.Push(i);
        }
       
        return results;
    }
}
