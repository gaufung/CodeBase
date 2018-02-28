public class Solution {
    public int RomanToInt(string s) {
         int res=0;
            if(string.IsNullOrEmpty(s)) return res;
            Stack<char> stack=new Stack<char>(s.Length);
            stack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                //如果栈为空，则进栈
                if(stack.Count==0)
                {
                    stack.Push(s[i]);
                    continue;
                }
                //如果不是小数字，则将其弹出，并且计算出结果
                if(!IsLittle(stack.Peek()))
                {
                    res+=Char2Value(stack.Pop());
                    stack.Push(s[i]);
                    continue;
                }
                ///如果是小数字
                else
                {
                    //如果是要入栈的数字为大数字
                    if(!IsLittle(s[i]))
                    {
                        if(Char2Value(s[i])>Char2Value(stack.Peek()))
                            res+=-1*Char2Value(stack.Pop());
                        else
                            res+=Char2Value(stack.Pop());
                        stack.Push(s[i]);    
                    }
                    //如果插入的数字为小数字
                    else
                    {
                        if(Char2Value(s[i])>Char2Value(stack.Peek()))
                            res+=-1*Char2Value(stack.Pop());
                        else
                            res+=Char2Value(stack.Pop());
                        stack.Push(s[i]);
                    }
                }
            }
            while (stack.Count!=0)
            {
                res+=Char2Value(stack.Pop());
            }
            return res;
    }
     private int Char2Value(char c)
        {
            int res=0;
            switch(c)
            {
                case 'I':
                    res=1;
                    break;
                case 'V':
                    res=5;
                    break;
                case 'X':
                    res=10;
                    break;
                case 'L':
                    res=50;
                    break;
                case 'C':
                    res=100;
                    break;
                case 'D':
                    res=500;
                    break;
                case 'M':
                    res=1000;
                    break;
                default :
                    break;
            }
            return res;
        }
        private bool IsLittle(char c)
        {
            if(c=='I'||c=='X'||c=='C')
                return true;
            else
                return false;
        }
}