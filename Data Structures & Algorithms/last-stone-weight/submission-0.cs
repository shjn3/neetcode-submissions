public class Solution {
    public class MyHeap{
        List<int> elements;
        public MyHeap(int[] stones){
            elements = new();

            for(int i =0;i<stones.Length;i++){
                this.heapify(stones[i]);
            }
        }

        public int Count(){
            return this.elements.Count;
        }

        public int Parent(int child){
            return (child-1)/2;
        }

        public int LeftChild(int parentId){
            return parentId*2+1;
        }
        
        public int RightChild(int parentId){
            return parentId*2+2;
        }

        public int Extract(){
            if(elements.Count==0) return -1;
            int res = elements[0];
            elements[0] = elements[^1];
            elements.RemoveAt(elements.Count-1);

            int length = elements.Count;
            int i = 0;
            while(i<=length){
                int left = LeftChild(i);
                int right = RightChild(i);
                int largest =i;
                if(left<elements.Count && elements[left]>elements[largest]){
                    largest = left;
                }

                if(right<elements.Count && elements[right]>elements[largest]){
                    largest = right;
                }

                if(largest !=i){
                    int temp = elements[i];
                    elements[i]= elements[largest];
                    elements[largest]=temp;
                    i = largest;
                }else{
                    break;
                }
            }
            return res;
        }

        public void Insert(int val){
            heapify(val);
        }

        private void heapify(int val){
            this.elements.Add(val);
            for(int i= (elements.Count-1)/2;i>=0;i--){
                int largest = i;
                int left = LeftChild(largest);
                int right = RightChild(largest);
                if(left<elements.Count && elements[left]>elements[largest]){
                    largest = left;
                }

                if(right<elements.Count && elements[right]>elements[largest]){
                    largest = right;
                }

                if(largest !=i){
                    int temp = elements[i];
                    elements[i]= elements[largest];
                    elements[largest]=temp;
                }
            }
        }
    }
    public int LastStoneWeight(int[] stones) {
        MyHeap _heap = new MyHeap(stones);

        while(_heap.Count()>1){
            int largest = _heap.Extract();
            int secondLargest = _heap.Extract();
            int newWeight = largest-secondLargest;
            if(newWeight==0) continue;
            _heap.Insert(newWeight);
        }

        return _heap.Count()==0?0:_heap.Extract();
    }
}
