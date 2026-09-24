public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int l =0;
        int r = points.Length-1;

        int pivot = points.Length;
        while(pivot!=k){
            pivot = Partition(points,l,r);
            if(pivot<k){
                l=pivot+1;
            }else{
                r = pivot-1;
            }
        }

        int[][] res = new int[k][];
        Array.Copy(points,res,k);
        return res;
    }

    public int Partition(int[][] points,int l , int r){
        int pivotIdx = r;
        int pivotDist  =Euclidean(points[pivotIdx]);
         int i= l;
         for(int j =l;j<r;j++){
            if(Euclidean(points[j])<=pivotDist){
                Swap(points,i,j);
                i++;
            }
         }
         Swap(points,i,r);
         return i;
    }

    public int Euclidean(int[] point){
        return point[0]*point[0]+point[1]*point[1];
    }

    public void Swap(int[][] points, int i,int j){
        var temp = points[i];
        points[i]= points[j];
        points[j] = temp;
    }
}
