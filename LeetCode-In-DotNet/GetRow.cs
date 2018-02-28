public class Solution {
    public IList<int> GetRow(int rowIndex) {
        if(rowIndex<0) return new List<int>();
        int[] row=new int[rowIndex+1];
        if(rowIndex>=0) row[0]=1;
        int temp;
        for(int i=1;i<=rowIndex;i++)
        {
            row[0]=1;
            row[i]=1;
            temp=1;
            for(int j=1;j<i;j++)
            {
                int oldValue=row[j];
                row[j]+=temp;
                temp=oldValue;
            }
        }
        return new List<int>(row);
    }
}