public class Solution {
    List<List<string>> res= new();
    public List<List<string>> SolveNQueens(int n) {
        BackTracking(n,new(), 0);
        return res;
    }

    public void BackTracking(int n,List<string> resolves, int row){
        if(resolves.Count==n ){
            res.Add(new List<string>(resolves));
            return;
        }

        if(row>=n){
            return;
        }

        for(int col =0;col<n;col++){
            if(isValid(resolves,col,row)){
                resolves.Add(spawnNextRow(n,col));
                BackTracking(n,resolves,row+1);
                resolves.RemoveAt(resolves.Count-1);
            }
        }
    }

    private string spawnNextRow(int n,  int col){
        string a = "";
        for(int i =0;i<n;i++){
            a+=(i==col)?'Q':'.';
        }

        return a;
    }

    private bool isValid(List<string> previous, int col, int row){
        for(int pRow =0;pRow<previous.Count;pRow++){
            string rowValue = previous[pRow];
            for(int i =0;i<rowValue.Length;i++){
                if(rowValue[i]=='.') continue;
                if(i==col) return false;
                if(Math.Abs(row-pRow) == Math.Abs(col-i)) return false;
            }
        }

        return true;
    }
}
