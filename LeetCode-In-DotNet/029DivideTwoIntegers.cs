public class Solution
{
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return Int32.MaxValue;
            if (dividend == 0) return 0;
            if(dividend==Int32.MinValue&&divisor==-1)return Int32.MaxValue;
            int dividen = dividend > 0 ? -1*dividend : dividend;
            int diviso = divisor > 0 ? -1*divisor : divisor;
            int isNegative = Math.Sign(dividend) != Math.Sign(divisor) ? -1 : 1;
            //now dividend and divisor are both negative
            int current = diviso;
            int times = 1;
            while (current > dividen)
            {
                times <<= 1;
                current <<= 1;
            }
            if (current == dividen) return isNegative*times;
            //Calcator
            int lo = current;
            int hi = current >> 1;
            int loTimes = times;
            int hiTimes = times>>1;
            //now the value is between hiTime and loTimes
            int miTimes = 0;
            while (hiTimes < loTimes)
            {
                miTimes = ((loTimes - hiTimes) >> 1) + hiTimes;
                int mi = ((hi - lo) >> 1) + lo;
                if (mi > dividen)
                {
                    hiTimes = miTimes;
                    hi = mi;
                }
                if (mi < dividen)
                {
                    loTimes = miTimes;
                    lo = mi;
                }
                if(mi==dividen)
                {
                    break;
                }
            }
            return miTimes*isNegative;
        }
    }