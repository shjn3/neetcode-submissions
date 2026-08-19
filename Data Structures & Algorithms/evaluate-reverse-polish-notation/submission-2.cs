public class Solution {
   const string plus ="+";
    const string minus ="-";
    const string asterisk ="*";
    const string slash ="/";
    public int EvalRPN(string[] tokens) {
        Stack<int> _stack  =new();
        int n =tokens.Length;

        // if(n==0){
        //     return 0;
        // }

        // if(n==1){
        //     if(int.TryParse(tokens[0],out int res)){
        //         return res;
        //     }else{
        //          return 0;
        //     }
        // }

        for(int i =0;i<n;i++){
            string token = tokens[i];
            if(token.Length==1){
               if(token!= plus & token!=minus && token!=asterisk && token!=slash){
                    _stack.Push(int.Parse(token));
                    continue;
               }
               int a = _stack.Pop();
               int b= _stack.Pop();
               _stack.Push(evaluate(b,a,token));
            }else{
                _stack.Push(int.Parse(token));
            }
        }

        return _stack.Pop();
    }

    public int evaluate(int a, int b, string opt){

        switch (opt){
            case plus:
                return a+b;
            case minus:
                return a-b;
            case asterisk:
                return a*b;
            case slash:
                return b==0?0: (int)(a/b);
        }
      return 0;
    }
}
