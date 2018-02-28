public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        int[] nums=new int[n];
        for(int i=0;i<n;i++)
            nums[i]=i+1;
        IList<int> item=new List<int>();
        IList<IList<int>> res=new List<IList<int>>();
        Combine(nums,item,res,k);
        return res;
    }
    
    private void Combine(int[] nums,IList<int> item,IList<IList<int>> res,int k)
    {
       if(item.Count==k)
       {
           res.Add(new List<int>(item));
           return;
       }
       for(int i=0;i<nums.Length;i++)
       {
          if(item.Count!=0&&item[item.Count-1]>=nums[i])
            continue;
          item.Add(nums[i]);
          Combine(nums,item,res,k);
          item.Remove(nums[i]);
       }
    }
}