public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        //search tree
        Array.Sort(nums);
        IList<IList<int>> res=new List<IList<int>>();
        Subset(nums,0,new List<int>(),res);
        res.Add(new List<int>());
        return res;
        
    }
    private void Subset(int[] nums,int start,IList<int> item,IList<IList<int>> res)
    {
        for(int i=start;i<nums.Length;i++)
        {
            if(i>start&&nums[i]==nums[i-1])
            {
                continue;
            }
            item.Add(nums[i]);
            res.Add(new List<int>(item));
            Subset(nums,i+1,item,res);
            item.RemoveAt(item.Count-1);
        }
    }
}