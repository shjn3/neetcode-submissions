public class MinStack {
    Stack<int> _stack;
    Stack<int> _prefixStack;
    int min = int.MaxValue;

    public MinStack() {
        _stack = new();
        _prefixStack = new();
    }
    
    public void Push(int val) {
        _stack.Push(val);

        min = Math.Min(min,val);
        _prefixStack.Push(val);
        _prefixStack.Push(min);
    }
    
    public void Pop() {
        _stack.Pop();    
        _prefixStack.Pop();
        _prefixStack.Pop();
        if(_prefixStack.Count==0){
            min = int.MaxValue;
        }else{
            min =_prefixStack.Peek();
        }
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return min;
    }
}
