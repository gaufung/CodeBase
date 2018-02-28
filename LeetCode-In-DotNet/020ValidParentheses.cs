public class Solution {
    public bool IsValid(string s) 
    {
        Stack<char> stack=new Stack<char>(s.Length);
        for(int i=0;i<s.Length;i++)
        {
            if(IsPush(s[i]))
            {
                stack.Push(s[i]);
            }
            else
            {
                if(stack.Count==0)
                    return false;
                else
                {
                    if(!IsMath(stack.Peek(),s[i]))
                        return false;
                    else
                    {
                        stack.Pop();
                    }
                }
            }
        }
        return stack.Count==0;
    }
    bool IsPush(char c)
    {
        return c=='('||c=='{'||c=='[';
    }
    bool IsMath(char leftChar,char rightChar)
    {
        //if equal, return false;
        if(leftChar==rightChar)
            return false;
        //if the the char is math
        //'('<->')'
        //'{'<->'}'
        //'['<->']'
        return Math.Abs(leftChar-rightChar)<=2;
    }
}