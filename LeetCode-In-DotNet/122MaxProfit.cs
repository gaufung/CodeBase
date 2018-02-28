public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length==0) return 0;
        int minIndex=0;
        int gain=0;
        for(int i=1;i<prices.Length;i++)
        {
            if(prices[i]<prices[i-1])
            {
               gain+=prices[i-1]-prices[minIndex];
               minIndex=i;
            }
        }
        if(prices[prices.Length-1]>prices[minIndex])
            gain+=prices[prices.Length-1]-prices[minIndex];
        return gain;
        
    }
  
}