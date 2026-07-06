public class Solution {
    public bool IsPalindrome(string s) {
        int left =0;
        int right = s.Length-1;
        while(left<=right){
            while(left<=right && !isValid(s[left])){
                left++;
            }

            while(left<=right && !isValid(s[right])){
                right--;
            }
            if(left>right) return true;

            char c1 = char.ToLower(s[left]);
            char c2 = char.ToLower(s[right]);
            if(c1!=c2) return false;
            left++;
            right--;
        }

        return true;
    }

    public bool isValid(char c){
        return  c>='0'&&c<='9'  || c>='A'&&c<='Z' || c>='a'&&c<='z';
    }
}
