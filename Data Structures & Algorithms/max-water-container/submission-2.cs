public class Solution {
    public int MaxArea(int[] heights) {
        int max =0;
        int left =0;
        int right =heights.Length-1;
        int iR = right;
        while(left<right){
            int heightLeft = heights[left];
            int heightRight = heights[right];
            int area = (right-left)*Math.Min(heightLeft,heightRight);

            if(area>max){
                max= area;
            }
            

            if(heightLeft<heightRight){
                while(left<right && heights[left]<=heightLeft){
                    left++;
                }
            }else{
                while(left<right && heights[right]<=heightRight){
                    right--;
                }
            }
        }

        return max;
    }
}
