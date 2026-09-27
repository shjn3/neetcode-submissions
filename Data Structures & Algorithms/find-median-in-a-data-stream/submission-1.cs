public class MedianFinder {
    PriorityQueue<int,int>pq;
    PriorityQueue<int,int>pq1;

    public MedianFinder() {
        pq1 = new();
        pq = new();
    }
    
    public void AddNum(int num) {
        pq.Enqueue(num,num);

        while(pq.Count>0 && pq.Count>pq1.Count+1){
            var v = pq.Dequeue();
            pq1.Enqueue(v,-v);
        }
        if(pq1.Count==0) return;

        while(pq.Count>0 && pq1.Count>0){
            if(pq.Peek()<pq1.Peek()){
                var v1 = pq.Dequeue();
                var v2 =pq1.Dequeue();
                pq.Enqueue(v2,v2);
                pq1.Enqueue(v1,-v1);
            }else{
                break;
            }
        }



       
    }
    
    public double FindMedian() {
        int total = pq1.Count+pq.Count;
        if(total==0) return 0;
        if(total%2==0){
            return (pq.Peek()+pq1.Peek())*0.5;
        }

        return pq.Peek();
    }
}
