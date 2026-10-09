public class Solution {
    private Dictionary<string, List<string>> adj;
    private List<string> res = new List<string>();
    public List<string> FindItinerary(List<List<string>> tickets) {
        adj = new();
        var sortedTickets = tickets.OrderByDescending(t => t[1]).ToList();

        for(int i =0;i<sortedTickets.Count;i++){
            var ticket = sortedTickets[i];
            if(!adj.ContainsKey(ticket[0])){
                adj.Add(ticket[0],new());
            }
            adj[ticket[0]].Add(ticket[1]);

        }
    


        DFS("JFK");

      res.Reverse();
      return res;
    }

    public void DFS(string current){
       while(adj.ContainsKey(current) && adj[current].Count>0){
        var dst = adj[current][adj[current].Count-1];
        adj[current].RemoveAt(adj[current].Count-1);
        DFS(dst);
       }

       res.Add(current);
    }
}
