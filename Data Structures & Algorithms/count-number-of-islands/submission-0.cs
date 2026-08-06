public class Solution {
    List<int> elements = new();
    public void union(int id1, int id2){
        int a = find(id1);
        int b= find(id2);
        if(a==b){
            return;
        }

        elements[a]=b;
    }
    
    public int find(int v){
        if(elements[v]==v){
            return v;
        }
        elements[v]=find(elements[v]);
        
        return  elements[v];
    }

    public int NumIslands(char[][] grid) {
        this.elements.Clear();
        int m =grid.Length;
        int n =grid[0].Length;
        for(int row = 0;row<m;row++){
            for(int col =0;col<n;col++){
                this.elements.Add(row*n+col);
            }
        }

       bool[][] visited = new bool[m][];
       for(int i =0;i<m;i++){
            visited[i] = new bool[n];
       }

        int[][] offsets = new int[][]{
            new int[]{
                1,0
            },
            new int[]{
                0,1
            },
        };

        bool isValid(int row, int col){
            return row>=0 && row<m && col>=0 && col<n;
        }

        for(int row = 0;row<m;row++){
            for(int col =0;col<n;col++){
                if(visited[row][col] || grid[row][col]=='0') continue;
                visited[row][col]=true;
                int id1 = row*n+col;
                foreach(var offset in offsets){
                    int nextRow =row +offset[0];
                    int nextCol = col+offset[1];
                    if(isValid(nextRow,nextCol)){
                        // Console.WriteLine("row: "+row+" "+col+" "+nextRow+" "+nextCol +" "+grid[nextRow][nextCol]);
                        if(grid[nextRow][nextCol]=='1'){

                            int id2= nextRow*n+nextCol;
                            this.union(id1,id2);
                        }
                    }
                }
            }
        }

        HashSet<int> islands = new();

        for(int i =0;i<elements.Count;i++){
            int row = i/n;
            int col = i%n;
            if(grid[row][col]=='1'){
                islands.Add(find(i));
            }
        }

        // foreach(var e in elements){
        //     Console.WriteLine("E: "+e);
        // }

        return islands.Count;
    }

}
