public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] amounts = new int[n];
        Stack<int> _stack =  new();
        for(int i=0;i<n;i++){
            int previousId = -1;
            int h = height[i];
            if(h==0) continue;
            while(_stack.Count>0 && height[_stack.Peek()]<=h){
                previousId = _stack.Pop();
            }
            _stack.Push(i);
            if(previousId!=-1){
                int minHeight = height[previousId];
                for(int j=previousId+1;j<i;j++){
                    int internalH  =minHeight-height[j];
                    amounts[j]= Math.Max(amounts[j],internalH);
                }
            }
        }

        while(_stack.Count>1){
            int lastId = _stack.Pop();
            int secondId = _stack.Peek();
            int h = height[lastId];
            for(int j =secondId+1;j<lastId;j++){
                int internalH  =h-height[j];
                amounts[j]= Math.Max(amounts[j],internalH);
            }
        }
    
        return amounts.Sum();
    }
}
