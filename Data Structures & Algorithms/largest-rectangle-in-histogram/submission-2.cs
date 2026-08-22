public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        if(n==1) return heights[0];

        int max =0;
        Stack<int> _stack = new();
        for(int i =0;i<n;i++){
            int height = heights[i];
            int firstId = _stack.Count>0?_stack.Peek():-1;
            while(_stack.Count>0 && height< heights[_stack.Peek()]){
                int peekId =_stack.Pop();
                int prevId = _stack.Count>0?_stack.Peek():-1;
                max = Math.Max(max,heights[peekId]*(firstId-prevId));
            }
            int id =_stack.Count>0?_stack.Peek():0;
            max = Math.Max(max,height*(i-id));
      
            _stack.Push(i);
        }

        if(_stack.Count==0) return max;
        int endId =_stack.Pop();

        while(_stack.Count>0){
            int remainId = _stack.Pop();
            int previousId= _stack.Count>0?_stack.Peek():-1;
            max=Math.Max(max,heights[remainId]*(endId-previousId));
        }



        return max;
    }
}
