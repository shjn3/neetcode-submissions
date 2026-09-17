public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        int n = triplets.Length;
        int tN = target.Length;
        int[] check = new int[tN];

        for(int i =0;i<n;i++){
            int[] tripletA = triplets[i];
            bool canMerge =true;
            for(int  j=0;j<tN;j++){
                if(tripletA[j]<=target[j]){
                    continue;
                }
                canMerge =false;
                break;
            }

            if(canMerge){
                for(int  j=0;j<tN;j++){
                   check[j] = Math.Max(check[j],tripletA[j]);
                }
            }
        }

        for(int  i=0;i<tN;i++){
            if(check[i]!=target[i]){
                return false;
            }
        }


        return true;
    }
}
