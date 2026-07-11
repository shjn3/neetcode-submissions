public class KthLargest {
    List<int> val =new();
    private int k;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        for(int i =0;i<nums.Length;i++){
            val.Add(nums[i]);
            Heapify();
        }
    }

    public int Parent(int child){ return(child-1)/2;}
    public int ChildLeft(int parentId){ return parentId*2+1;}
    public int ChildRight(int parentId){ return parentId*2+2;}
    public void Heapify(){
        int length = val.Count;
        for(int i =length/2;i>=0;i--){
            int left = ChildLeft(i);
            int right = ChildRight(i);
            int largest = i;
            if(left<length &&val[left]>val[largest]){
                largest = left;
            } 

            if(right<length && val[right]>val[largest]){
                largest = right;
            }

            if(largest!=i){
                int temp = val[i];
                val[i]=val[largest];
                val[largest]=temp;
            }
        }
    }

    public int extract(){
        if(val.Count==0) return 0;
        int _v = val[0];
        val[0] = val[^1];
        int length = val.Count;
        val.RemoveAt(length-1);
        int cursor = 0;
        while(cursor<length-1){
            int left = ChildLeft(cursor);
            int right = ChildRight(cursor);
            int largest =cursor;
            if(left<length-1 && val[largest]<val[left]){
                largest = left;
            }
            if(right<length-1 && val[largest]<val[right]){
                largest = right;
            }
            if(largest!=cursor){
                int temp = val[cursor];
                val[cursor]=val[largest];
                val[largest]=temp;
                cursor = largest;
            }else{
                break;
            }
        }

        return _v;
    }
    
    public int Add(int v) {
        val.Add(v);
        Heapify();
        int[] temp = new int[k];
        for(int i =0;i<temp.Length;i++){
            temp[i] = extract();
        }
        for(int i =0;i<temp.Length;i++){
            Add2(temp[i]);
        }

        return temp[^1];
    }


    private void Add2(int v){
        val.Add(v);
        Heapify();
    }
}
