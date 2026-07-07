public class MinStack {
    Stack<int> _stack;
    Stack<int> _prefixStack;


    public MinStack() {
        _stack = new();
        _prefixStack = new();
    }
    
    public void Push(int val) {
        _stack.Push(val);

        if(_prefixStack.Count==0){
            _prefixStack.Push(val);
        }else{
            if(_prefixStack.Peek()>=val){
                _prefixStack.Push(val);
            }
        }      
    }
    
    public void Pop() {
        int val = _stack.Pop();    
        if(val == _prefixStack.Peek()){
            _prefixStack.Pop();
        }

    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _prefixStack.Peek();
    }
}
