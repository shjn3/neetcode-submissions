public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix[0][0]>target || matrix[^1][^1]<target) return false;
        //Find row
        int rowId = this.findRow(matrix,target);
        if(rowId==-1) return false;
        int idx =this.binarySearch(matrix[rowId],target);
        return idx!=-1;
    }

    public int binarySearch(int[] arr, int target){
        int l =0;
        int r=  arr.Length-1;
        while(l<=r){
            int m = l+(r-l)/2;
            if(arr[m]==target) return m;
            if(arr[m]>target){
                r=m-1;
            }else{
                l=m+1;
            }
        }

        return -1;
    }

    public int findRow(int[][] matrix, int target){
        int l = 0;
        int r = matrix.Length-1;

        while(l<=r){
            int m = l+(r-l)/2;
            if(matrix[m][0]<=target && matrix[m][^1]>=target){
                return m;
            }
            if(matrix[m][0]>target) {
                r=m-1;
            }else{
                l=m+1;
            }
        }

        return -1;
    }
}
