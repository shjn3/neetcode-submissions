public class Solution {
    List<int> elements = new();
    public int find(int v){
        if(this.elements[v]==v){
            return v;
        }
        elements[v] = find(elements[v]);
        return elements[v];
    }

    public void Union(int a, int b){
        int rootA = find(a);
        int rootB = find(b);
        if(rootA==rootB) return;
        this.elements[rootA] = rootB;
    }

    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m*n;
        for(int i =0;i<total;i++){
            this.elements.Add(i);
        }
        int[][] offsets = new int[][]{
            new int[]{
                0,1
            },
            new int[]{
                1,0
            }
        };

        for(int row=0;row<m;row++){
            for(int col = 0;col<n;col++){
                if(grid[row][col]==0) continue;
                int idA = row*n+col;
                foreach(var offset in offsets){
                    int nextRow = row + offset[0];
                    int nextCol  = col +offset[1];
                    if(nextRow>=0 && nextRow<m && nextCol>=0 && nextCol<n){
                        if(grid[nextRow][nextCol]==1){
                            this.Union(idA, nextRow*n+nextCol);
                        }
                    }
                }
            }
        }
        int max =0;
        Dictionary<int,int> countMap = new();
        for(int i =0;i<this.elements.Count;i++){
            int r = i/n;
            int c = i%n;
            if(grid[r][c]==1){
                int parent = this.find(i);
                countMap.TryAdd(parent,0);
                countMap[parent]+=1;
                max = Math.Max(max,countMap[parent]);
            }
        }

        // foreach(var kvp in countMap){
        //     Console.WriteLine("Key: "+kvp.Key+" "+kvp.Value);
        // }

        return max;
    }
}
