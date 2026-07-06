public class Solution {
    public bool IsPalindrome(string s) {
        List<char> _l = new();
        for(int i =0;i<s.Length;i++){
            char c = s[i];
            if(c>='0'&&c<='9'  || c>='A'&&c<='Z' || c>='a'&&c<='z'){
                _l.Add(char.ToLower(c));
            }
        }

        int left =0;
        int right = _l.Count-1;
        while(left<=right){
            if(_l[left]!=_l[right]) return false;
            left++;
            right--;
        }

        return true;

    }
}
