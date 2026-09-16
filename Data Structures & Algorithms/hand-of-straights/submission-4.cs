public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        int n = hand.Length;
        if(n%groupSize!=0) return false;

        Dictionary<int, int> countMap = new();
        int min = int.MaxValue;
        int max =int.MinValue;
        for(int j =0;j<n;j++){
            min = Math.Min(min,hand[j]);
            max = Math.Max(max,hand[j]);
            if(!countMap.ContainsKey(hand[j])){
                countMap.Add(hand[j],0);
            }
            countMap[hand[j]]+=1;
        }

        int i = min;
        // int count =0;
        while(i<=max){
            if(!countMap.ContainsKey(i) || countMap[i]==0){
                i++;
                continue;
            }

            int start  = i;
            while(start<i+groupSize){
                if(countMap.ContainsKey(start) && countMap[start]>0){
                   countMap[start]-=1;
                   start+=1;
                //    count++;
                }else{
                     return false;
                }
            }
        }

        // Console.WriteLine("Count: "+count);

     

        // return count==n;
        return true;
    }
}
