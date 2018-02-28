public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res=new List<IList<int>>();
        if(numRows<1)return res;
        if(numRows>=1) res.Add(new List<int>{1});
        if(numRows>=2) 
        {
            res.Add(new List<int>{1,1});
        }
        for(int i=3;i<= numRows;i++)
        {
            IList<int> item=new List<int>();
            item.Add(1);
            for(int j=2;j<i;j++)
            {
                item.Add(res[i-2][j-2]+res[i-2][j-1]);
            }
            item.Add(1);
            res.Add(item);
        }
        return res;
    }
}