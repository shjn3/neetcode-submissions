public class Solution {

        private Dictionary<int,int> parent = new();
        private Dictionary<int,int> size = new();
        private int max=0;
        public int Find(int a){
            if(parent[a]!=a){
                parent[a]=Find(parent[a]);
            }

            return parent[a];
        }

        public void Insert(int a){
            if(!parent.ContainsKey(a)){
                parent.Add(a,a);
                size.Add(a,1);
                max = 1;
            }
        }

        public void Union(int a, int b){
            int rootA = Find(a);
            int rootB = Find(b);
            if(rootA == rootB) return;

            if(size[rootA]<size[rootB]){
                int temp = rootA;
                rootA = rootB;
                rootB = temp;
            }
            // Console.WriteLine("RootB: "+parent[rootB] +" "+rootA);
            // parent[rootB] = 1;
            parent[rootB] = rootA;
            size[rootA] += size[rootB];
            max = Math.Max(max,size[rootA]);
        }
     

     public int LongestConsecutive(int[] nums) {
        if (nums == null || nums.Length == 0) 
        {
            return 0;
        }
        HashSet<int> _set = new HashSet<int>(nums);
        foreach( var num in _set){
             Insert(num);
        }

        foreach(var num in _set){
            if(_set.Contains(num-1)){
                Union(num,num-1);
            }

            if(_set.Contains(num+1)){
                Union(num,num+1);
            }
        }

        // foreach(var pair in parent){
        //     Console.WriteLine("Parent: "+pair.Key+" "+pair.Value);
        // }
       
        return max;
    }
}
