public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
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
            if(i>start && candidates[i]==candidates[i-1]) continue; 
            item.Add(candidates[i]);
            Find(candidates,i+1,target-candidates[i],item,res);
            item.RemoveAt(item.Count-1);
        }
    }
}