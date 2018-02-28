public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<int> item=new List<int>();
        IList<IList<int>> res=new List<IList<int>>();
        Find(candidates,0,target,item,res);
        return res;
    }
    
    private void Find(int[] candidates,int start,int target,IList<int> item,IList<IList<int>> res)
    {
        if(target<0)
            return;
        if(target==0)
        {
            res.Add(new List<int>(item));
            return;
        }
        for(int i=start;i<candidates.Length;i++)
        {           
            item.Add(candidates[i]);
            Find(candidates,i,target-candidates[i],item,res);
            item.RemoveAt(item.Count-1);
        }
    }
}