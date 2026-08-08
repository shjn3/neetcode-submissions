/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node==null) return null;
        Node root = new Node(node.val);

        if(node.neighbors.Count==0) return root;

        Dictionary<int,Node> cache = new();
        cache.Add(node.val,root);

        HashSet<Node> used = new();
        Queue<Node> nodes = new();
        nodes.Enqueue(node);
        while(nodes.Count>0){
            var n = nodes.Dequeue();
            if(used.Contains(n)) continue;
            used.Add(n);
            cache.TryGetValue(n.val,out var newNode);
            
            if(newNode==null){
                newNode = new Node(n.val);
                cache.Add(n.val,newNode);
            }

            foreach(var neighbor in n.neighbors){
                cache.TryGetValue(neighbor.val,out Node newNodeNeighbor);
                if(newNodeNeighbor==null){
                    newNodeNeighbor = new Node(neighbor.val);
                    cache.Add(neighbor.val,newNodeNeighbor);
                }
                newNode.neighbors.Add(newNodeNeighbor);
                nodes.Enqueue(neighbor);
            }
        }

        return root;
    }
}
