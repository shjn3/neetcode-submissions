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

        var dist = new Dictionary<int,int>();
        var tempDist = new Dictionary<int,int>();
        dist.Add(src,0);
        tempDist.Add(src,0);

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
                    if(!dist.ContainsKey(neighborId)){
                        dist.Add(neighborId,int.MaxValue);
                    }

                    if(!tempDist.ContainsKey(neighborId)){
                        tempDist.Add(neighborId,int.MaxValue);
                    }

                    if( dist[neighborId] > nextPrice){
                        if(tempDist[neighborId]==dist[neighborId]){
                            nextQ.Add(neighborId);
                        }
                        tempDist[neighborId] = Math.Min(tempDist[neighborId],nextPrice);
                    }
                }
            }

            foreach(var kvp in tempDist){
               dist[kvp.Key]=kvp.Value;
            }

            var t = currentQ;
            currentQ = nextQ;
            nextQ = t;
            nextQ.Clear();

            k--;
        }
        if(!dist.ContainsKey(dst) || dist[dst]==int.MaxValue) return -1;
        return dist[dst];
    }
}
