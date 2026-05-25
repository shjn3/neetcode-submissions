public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int length = s.Length;
        if(length<=1) return length;

        int start =0;
        int end =0;
        int maxLength =1;

        for(int i =1;i<length;i++){
            int cursor = start;
            bool isEqual = false;
            while(cursor<=end){
                if(s[cursor]==s[i]){
                    start = cursor+1;
                    end=i;
                    isEqual= true;
                    break;
                }
                cursor++;
            }

            if(!isEqual){
                end++;
            }
             maxLength = Math.Max(maxLength,end-start+1);

        }
        return maxLength;
    }
}
