public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<int,int> dic=new Dictionary<int,int>();
        IList<IList<string>> res=new List<IList<string>>();
        for(int i=0;i<strs.Length;i++)
        {
            int hashCode=GetCode(strs[i]);
            if(dic.ContainsKey(hashCode))
            {
                IList<string> item=res[dic[hashCode]];
                int insertPos=FindInsertPos(item,strs[i]);
                item.Insert(insertPos,strs[i]);
            }
            else
            {
                IList<string> item=new List<string>{strs[i]};
                res.Add(new List<string>(item));
                dic.Add(hashCode,res.Count-1);
            }
        }
        return res;
    }
    int GetCode(string str)
    {
        var chars=str.ToArray();
        Array.Sort(chars);
        return new string(chars).GetHashCode();
    
    }
    int FindInsertPos(IList<string> item,string insertStr)
    {
        int index=0;
        foreach(string str in item)
        {
            if(String.Compare(insertStr,str)<=0)
              break;
            else
             index++;
        }
        return index;
    }
}