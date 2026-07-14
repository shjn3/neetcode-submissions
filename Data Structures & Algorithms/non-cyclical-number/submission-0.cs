public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> usedNumber = new();
        while(true){
            int total =0;
            if(usedNumber.Contains(n)) return false;
            usedNumber.Add(n);
            while(n>=10){
                int digits = n%10;
                total+= digits*digits;
                n/=10;
            }

            total+=n*n;
            if(total==1) return true;
            n=total;
        }


      return false;
    }
}
