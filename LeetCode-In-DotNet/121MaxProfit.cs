public class Solution {
    public int MaxProfit(int[] prices) {
        /*
        if(prices.Length==0) return 0;
        int[] profits=new int[prices.Length];
        profits[0]=0;
        for(int i=1;i<prices.Length;i++)
        {
            int ithProfit=int.MinValue;
            for(int j=0;j<=i;j++)
            {
                if(prices[i]<=prices[j]) continue;
                if((prices[i]-prices[j])>ithProfit)
                    ithProfit=prices[i]-prices[j];
            }
            profits[i]=Math.Max(profits[i-1],ithProfit);
        }
        return profits[prices.Length-1];
        */
        if (prices == null || prices.Length <= 1){
            return 0;
        }
        int minPrice = prices[0];
        int profit = 0;

        for (int i = 0; i < prices.Length; i++){
            int diff = prices[i] - minPrice;
            if (diff > profit){
                profit = diff;
            }
            if (prices[i] < minPrice){
                minPrice = prices[i];
            }
        }
        return profit;
    }
}