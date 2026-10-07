public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adj = new Dictionary<int,List<(int,int)>>();

        for(int i =0;i<flights.Length;i++){
            var flight = flights[i];
            var flightSource= flight[0];
            var flightDestination = flight[1];
            var flightPrice = flight[2];
            if(!adj.ContainsKey(flightSource)){
                adj.Add(flightSource,new());
            }
            adj[flightSource].Add((flightDestination,flightPrice));
        }

        var dist = new int[n];
        int[] tempDist = new int[n];
        Array.Fill(dist,int.MaxValue);
        dist[src]=0;
        Queue<List<int>> q = new();
        Array.Copy(dist,tempDist,n);
        List<int> currentQ = new();
        currentQ.Add(src);
        List<int> nextQ = new();

        while(currentQ.Count>0 && k>=0){
            foreach(var id  in currentQ){
                if(!adj.ContainsKey(id)) continue;
    
                foreach(var neighbor in adj[id]){
                    var neighborId = neighbor.Item1;
                    var neighborPrice = neighbor.Item2;
                    var nextPrice =dist[id]+neighborPrice;
                    if( dist[neighborId] > nextPrice){
                        if(tempDist[neighborId]==dist[neighborId]){
                            nextQ.Add(neighborId);
                        }
                        tempDist[neighborId] = Math.Min(tempDist[neighborId],nextPrice);
                    }
                }
            }

            Array.Copy(tempDist,dist,n);
            var t = currentQ;
            currentQ = nextQ;
            nextQ = t;
            nextQ.Clear();

            k--;
        }
    
        return dist[dst]==int.MaxValue?-1:dist[dst];
    }
}
