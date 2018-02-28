public class Solution {
    public int Reverse(int x) {
        int sign=Math.Sign(x);
            List<int> digits=new List<int>();
            if ((x==Int32.MinValue))
            {
                return 0;
            }
            x=Math.Abs(x);
            while(x>0)
            {
                digits.Add(Math.Abs(x%10));
                x/=10;
            }
            int res=0;
            try
            {
                for (int i = 0; i < digits.Count; i++)
                {
                    res = checked(res * 10 + digits[i]);
                }
            }
            catch (OverflowException e)
            {
                res=0;
            } 
            return res*sign;
    }
}