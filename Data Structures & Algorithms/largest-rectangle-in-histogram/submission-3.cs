public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        if(n==1) return heights[0];

        Stack<Tuple<int,int>> stack = new();

        int i =0;
        int maxArea = 0;
        while(i<n){
            int start = i;
            while(stack.TryPeek(out var previous) && previous.Item2> heights[i]){
                stack.Pop();
                start = previous.Item1;
                maxArea = Math.Max(maxArea,(i-previous.Item1)*previous.Item2);
            }

            stack.Push(new Tuple<int,int>(start,heights[i]));
            i++;
        }

        while(stack.TryPeek(out var previous)){
                stack.Pop();
                maxArea = Math.Max(maxArea,(n-previous.Item1)*previous.Item2);
        }

        return maxArea;
    }
}
