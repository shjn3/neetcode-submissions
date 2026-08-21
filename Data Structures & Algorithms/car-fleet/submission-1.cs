public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int count = 1;
        int n = speed.Length;
        if(n==1) return 1;
        Dictionary<int,int> _map = new();
        for(int  i=0;i<n;i++){
           _map.Add(position[i],speed[i]);
        }

        Array.Sort(position);
        Stack<int> _stack = new();
        _stack.Push(position[^1]);

        for(int i =n-2;i>=0;i--){
            var _p = position[i];
            var _s = _map[_p];
            
            while(_stack.Count>0){
                int peekID = _stack.Peek();
                int peekV = _map[peekID];
                if(peekV>=_s){
                    _stack.Pop();
                    continue;
                }
                float point =FindCatchupPoint(peekID,_p,peekV,_s);
                if(point==-1 || point>target){
                     _stack.Pop();
                    continue;
                }
                break;
            }

            if(_stack.Count==0){
                count++;
            }

            _stack.Push(_p);
        }

        return count;
    }

    public float FindCatchupPoint(int it1, int it2, int vt1,int vt2){
        if(vt1==vt2) return -1;
        int i1,i2,v1,v2;
        if(it1>it2){
            i1=it1;
            i2=it2;
            v1=vt1;
            v2=vt2;
        }else{
            i1=it2;
            i2=it1;
            v1=vt2;
            v2=vt1;
        }
        
        if(v1>v2) return -1;
        
        
        return i1+(i1-i2)*1f/(v2-v1)*v1;
    }
}
