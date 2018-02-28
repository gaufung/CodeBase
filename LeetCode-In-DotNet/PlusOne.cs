public class Solution {
    public int[] PlusOne(int[] digits) {
        if(digits==null || digits.Length==0)
            return null;
        //判断是否所有
        bool IsAllNine=true;
        for(int i=0;i<digits.Length;i++)
        {
            if(digits[i]!=9)
            {
                IsAllNine=false;
                break;
            }
        }
        //如果所有数字都是9
        if(IsAllNine)
        {
            int[] res=new int[digits.Length+1];
            res[0]=1;
            return res;
        }
        //如果不是9
        bool IsNeedPlusOne=true;
        for(int i=digits.Length-1;i>=0;i--)
        {
            if(IsNeedPlusOne)
            {
                if(digits[i]+1>=10)
                    IsNeedPlusOne=true;
                else
                    IsNeedPlusOne=false;
                digits[i]=(digits[i]+1)%10;
            }
            else
            {
                break;
            }
        }
        return digits;
    }
}