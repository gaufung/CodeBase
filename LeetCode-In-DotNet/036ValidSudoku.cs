public class Solution {
    public bool IsValidSudoku(char[,] board) {
        if(board==null || board.GetLength(0)!=9 || board.GetLength(1)!=9)
            return false;
        Dictionary<char,List<Postion>> dic=new Dictionary<char,List<Postion>>(9);
        for(int i=0;i<9;i++)
        {
            for(int j=0;j<9;j++)
            {
                char cell=board[i,j];
                if(IsNumber(cell))
                {
                    Postion pos=new Postion(i,j);
                    if(!dic.ContainsKey(cell))
                    {
                        dic.Add(cell,new List<Postion>(){pos});
                    }
                    //包含key
                    else
                    {
                        for(int k=0;k<dic[cell].Count;k++)
                        {
                            if(!dic[cell][k].Valid(pos))
                                return false;
                        }
                        dic[cell].Add(pos);
                    }
                }
            }
        }
        return true;
    }
    //判断是否是否为数字
    bool IsNumber(char c)
    {
        return c>='1'&&c<='9';
    }
    class Postion
    {
        public int x;
        public int y;
        public Postion(int x,int y)
        {
            this.x=x;
            this.y=y;
        }
        public bool Valid(Postion other)
        {
            if(other.x==x || other.y==y)
                return false;
            if(other.x/3==x/3 && other.y/3==y/3)
                return false;
            return true;
        }
    }
}