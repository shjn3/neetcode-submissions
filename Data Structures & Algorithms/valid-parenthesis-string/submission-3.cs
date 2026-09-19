public class Solution {
    public bool CheckValidString(string s) {
        int n = s.Length;
        Stack<int> startIndices = new();
        Stack<int> leftParathesis =new();
    
        int startCount =0;
        for(int i =0;i<n;i++){
            if(s[i]=='('){
                leftParathesis.Push(i);
            }else if(s[i]=='*'){
                startIndices.Push(i);
            }else if (s[i]==')'){
                if(leftParathesis.Count>0){
                    leftParathesis.Pop();
                }else{
                    if(startIndices.Count==0) return false;
                    startIndices.Pop();
                }
            }
        }

        if(leftParathesis.Count==0) return true;
        bool canResolve = false;
        if(leftParathesis.Count> startIndices.Count) return false;
        while(leftParathesis.Count>0 &&  startIndices.Count>0){
            if(leftParathesis.Peek()> startIndices.Peek()){
                break;
            }   
            leftParathesis.Pop();
            startIndices.Pop();
        }

        return  leftParathesis.Count==0;
    }
}
