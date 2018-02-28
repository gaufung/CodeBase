public class Solution {
    public void Solve(char[,] board) {
        if(board==null) return;
        IList<Position> positions=Init(board);
        bool[,] status=new bool[board.GetLength(0),board.GetLength(1)];
        IList<Position> reversePostions=new List<Position>();
        int v=0;
        while(v<positions.Count)
        {
            Position pos=positions[v];
            if(!status[pos.x,pos.y])
            {
                Bfs(pos,status,board,reversePostions);
            }
            v++;
        }
        for (int i = 0; i <board.GetLength(0) ; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i,j]='X';
            }
        }
        foreach (var item in reversePostions)
        {
            board[item.x,item.y]='O';
        }
        
    }
    private void Bfs(Position start,bool[,] status,char[,] board,IList<Position> reversePostions)
    {
        Queue<Position> queue=new Queue<Position>();
        queue.Enqueue(start);
        while (queue.Count!=0)
        {
            Position pos =queue.Dequeue();
            reversePostions.Add(pos);
             status[pos.x,pos.y]=true;
            if(pos.x-1>=0 && status[pos.x-1,pos.y]==false && board[pos.x-1,pos.y]=='O')
                queue.Enqueue(new Position(pos.x-1,pos.y));
            if(pos.x+1<board.GetLength(0) && status[pos.x+1,pos.y]==false && board[pos.x+1,pos.y]=='O')
                queue.Enqueue(new Position(pos.x+1,pos.y));
            if(pos.y-1>=0 && status[pos.x,pos.y-1]==false && board[pos.x,pos.y-1]=='O')
                queue.Enqueue(new Position(pos.x,pos.y-1));
            if(pos.y+1<board.GetLength(1) && status[pos.x,pos.y+1]==false && board[pos.x,pos.y+1]=='O')
                queue.Enqueue(new Position(pos.x,pos.y+1));
        }
    }
    private void Travese(Position start,bool[,] status,char[,] board)
    {
        Queue<Position> queue=new Queue<Position>();
        queue.Enqueue(start);
        bool res=false;
        IList<Position> resPos=new List<Position>();
        while(queue.Count!=0)
        {
            Position pos = queue.Dequeue();
            res |= Check(pos,board);
            resPos.Add(pos);
            status[pos.x,pos.y]=true;
            if(pos.x-1>=0 && status[pos.x-1,pos.y]==false && board[pos.x-1,pos.y]=='O')
                queue.Enqueue(new Position(pos.x-1,pos.y));
            if(pos.x+1<board.GetLength(0) && status[pos.x+1,pos.y]==false && board[pos.x+1,pos.y]=='O')
                queue.Enqueue(new Position(pos.x+1,pos.y));
            if(pos.y-1>=0 && status[pos.x,pos.y-1]==false && board[pos.x,pos.y-1]=='O')
                queue.Enqueue(new Position(pos.x,pos.y-1));
            if(pos.y+1<board.GetLength(1) && status[pos.x,pos.y+1]==false && board[pos.x,pos.y+1]=='O')
                queue.Enqueue(new Position(pos.x,pos.y+1));
        }
        if(!res)
        {
            foreach(Position pos in resPos)
            {
                board[pos.x,pos.y]='X';
            }
        }
        
    }
    private bool Check(Position pos,char[,] board)
    {
        return pos.x==0 || pos.x==board.GetLength(0)-1 || 
            pos.y==0 || pos.y==board.GetLength(1)-1;
    }
    private IList<Position> Init(char[,] board)
    {
        ISet<Position> res=new HashSet<Position>();
        // for(int i=0;i<board.GetLength(0);i++)
        // {
        //     for(int j=0;j<board.GetLength(1);j++)
        //     {
        //         if(board[i,j]=='O')
        //             res.Add(new Position(i,j));
        //     }
        // }
        for(int j=0;j<board.GetLength(1);j++)
        {
            if(board[0,j]=='O')
                res.Add(new Position(0,j));
            if(board[board.GetLength(0)-1,j]=='O')
                res.Add(new Position(board.GetLength(0)-1,j));
        }
        for(int i=0;i<board.GetLength(0);i++)
        {
            if(board[i,0]=='O')
                res.Add(new Position(i,0));
            if(board[i,board.GetLength(1)-1]=='O')
                res.Add(new Position(i,board.GetLength(1)-1));
        }
        return res.ToList();
    }
    internal class Position
    {
        public int x;
        public int y;
        public Position(int xx,int yy)
        {
            this.x=xx;
            this.y=yy;
        }
        public override bool Equals(object obj)
        {
            Position pos=obj as Position;
            if(pos==null)
                return false;
            return pos.x==x && pos.y==y;
        }
    }
    
}