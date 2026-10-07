public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adj = new List<(int,int)>[n];

        for(int i =0;i<flights.Length;i++){
            var flight = flights[i];
            var flightSource= flight[0];
            var flightDestination = flight[1];
            var flightPrice = flight[2];
            adj[flightSource] ??= new();
            adj[flightSource].Add((flightDestination,flightPrice));
        }

        var dist = new int[n];
        int[] tempDist = new int[n];
        Array.Fill(dist,int.MaxValue);
        dist[src]=0;
        Queue<List<int>> q = new();
        q.Enqueue(new (){src});
        Array.Copy(dist,tempDist,n);
        while(q.Count>0 && k>=0){
            var idArr = q.Dequeue();
            List<int> nextQ = new();

            foreach(var id  in idArr){
                if(adj[id]==null) continue;
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

            q.Enqueue(nextQ);
            k--;
        }
    
       foreach(var d in dist){
        Console.WriteLine("Dist: "+d);
       }
        return dist[dst]==int.MaxValue?-1:dist[dst];
    }
}
