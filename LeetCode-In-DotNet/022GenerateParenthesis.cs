public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<string> res=new List<string>();
        if(n<=0)
            return res;
        else
            Parenthesis(n,n,"",res);
        return res;
        
    }
    private void Parenthesis(int left,int right,string str,List<string> res)
    {
        if(right<left)
            return;
        if(right==0&&left==0)
            res.Add(str);
        if(left>0)
            Parenthesis(left-1,right,str+"(",res);
        if(right>0)
            Parenthesis(left,right-1,str+")",res);
    }
}