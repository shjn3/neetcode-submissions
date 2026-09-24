public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        PriorityQueue<int,double> q = new();

        for(int i =0;i <points.Length;i++){
            var point = points[i];
            double l = Math.Sqrt(point[0]*point[0]+point[1]*point[1]);
            q.Enqueue(i,l);
        }

        int[][] res = new int[k][];

        for(int i =0;i<k;i++){
            var v = q.Dequeue();
            res[i] = points[v];
        }


        return res;
    }
}
