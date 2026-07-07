public class Solution {
    public bool IsValid(string s) {
        Stack<char> _stack  = new();

        for(int i =0;i<s.Length;i++){
            char c = s[i];
            if(canAdd(c)){
                _stack.Push(c);
                continue;
            }
            if(_stack.Count==0) return false;
            char openBracket = _stack.Pop();
            if(!isSameType(openBracket,c)) return false;
        }

        return _stack.Count==0;
    }

    public bool isSameType(char c, char c2){
        if(c=='(') return c2==')';
        if(c=='[') return c2==']';
        if(c=='{') return c2=='}';
        return false;
    }

    public bool canAdd(char c){

        return c=='('||c=='{'||c=='[';
    }
}
