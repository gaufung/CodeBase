public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        if(triangle==null) return 0;
        IList<IList<int>> ways=new List<IList<int>>();
        //init 
        int row=triangle.Count;
        int sum=0;
        IList<int> item=new List<int>();
        for(int i=0;i<row;i++)
        {
            sum+=triangle[i][0];
            item.Add(sum);
        }
        ways.Add(item);
        //the increase equalition
        for(int i=1;i<row;i++)
        {
            IList<int> rowItem=new List<int>();
            ways.Add(rowItem);
            rowItem.Add(ways[i-1][0]+triangle[i][i]);
            for(int j=1;j<row-i;j++)
            {
                int cellValue=triangle[j+i][i];
                rowItem.Add(Math.Min(ways[i-1][j],ways[i][j-1])+cellValue);
            }
            
        }
        int minValue=int.MaxValue;
        foreach(var way in ways)
        {
            if(way[way.Count-1]<minValue)
                minValue=way[way.Count-1];
        }
        return minValue;
    }
   
}