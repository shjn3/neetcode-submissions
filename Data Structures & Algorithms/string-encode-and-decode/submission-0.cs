public class Solution {

    public string Encode(IList<string> strs) {
        string res = "";
        for(int i =0;i<strs.Count;i++){
            int length = strs[i].Length;
            res+="("+length.ToString()+")"+strs[i];
        }
        return res;
    }

    public List<string> Decode(string s) {
        List<string> res = new();
        int cursor =0;
        int sLength =s.Length;
        while(cursor<sLength){
            Find(s,cursor, out int startId, out int length);
            res.Add(s.Substring(startId,length));
            cursor = startId+length;
        }

        return res;
    }

    private void  Find(string s, int fromIdx,out int startId, out int length){
        int end=fromIdx;
        int sLength = s.Length;
        int j =fromIdx+1;
        while(j<sLength&& s[j]!=')'){
            j++;
        }
        string numberLength = s.Substring(fromIdx+1,j-fromIdx-1);

        length = int.Parse(numberLength);
        startId = j+1;
    }
}
