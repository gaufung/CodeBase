public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        Array.Sort(nums);
        IList<int> item=new List<int>();
        IList<IList<int>> res=new List<IList<int>>();
        Permute(nums,item,res);
        return res;
    }
    private void Permute(int[] nums,IList<int> item,IList<IList<int>> res)
    {
        if(item.Count==nums.Length)
        {
            res.Add(new List<int>(item));
            return;
        }
        for(int i=0;i<nums.Length;i++)
        {
            if(item.Contains(nums[i]))
                continue;
            item.Add(nums[i]);
            Permute(nums,item,res);
            item.RemoveAt(item.Count-1);
        }
    }
}