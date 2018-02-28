public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        Array.Sort(nums);
        int[] bits=new int[nums.Length];
        IList<IList<int>> res=new List<IList<int>>();
        Order(bits,nums,res);
        return res;
    }
    private void Order(int[] bits,int[] nums,IList<IList<int>> res)
    {
        IList<int> item=new List<int>();
        for(int i=0;i<bits.Length;i++)
        {
            if(bits[i]==1)
                item.Add(nums[i]);
        }
        res.Add(item);
        for(int i=0;i<bits.Length;i++)
        {
            if(i<=LastIndex(bits))
                continue;
            bits[i]=1;
            Order(bits,nums,res);
            bits[i]=0;
        }
    }
    private int LastIndex(int[] bits)
    {
        int index=bits.Length-1;
        while(index>=0)
        {
            if(bits[index]==1)
                break;
            index--;
        }
        return index;
    }
}