/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<TreeNode> GenerateTrees(int n) {
        if(n==0) return new List<TreeNode>();
        IList<IList<TreeNode>> values=new List<IList<TreeNode>>();
        IList<TreeNode> first=new List<TreeNode>(){new TreeNode(1)};
        values.Add(first);
        //主循环，用来计算保存结果
        for(int i=2;i<=n;i++)
        {
            IList<TreeNode> item=new List<TreeNode>();
            //次循环，计算一次为数值j为跟根节点，左右两个部分组成的结果计算
            for(int j=1;j<=i;j++)
            {
                int leftCount=j-1;
                int rightCount=i-j;
                IList<TreeNode> leftChild=leftCount==0?new List<TreeNode>():values[leftCount-1];
                IList<TreeNode> rightChild=rightCount==0?new List<TreeNode>():values[rightCount-1];
                if(leftChild.Count==0&&rightChild.Count!=0)
                {
                    foreach(var right in rightChild)
                    {
                        TreeNode root=new TreeNode(j);
                        root.right=Copy(right);
                        item.Add(root);
                    }
                }
                if(leftChild.Count!=0&&rightChild.Count==0)
                {
                    foreach(var left in leftChild)
                    {
                        TreeNode root=new TreeNode(j);
                        root.left=Copy(left);
                        item.Add(root);
                    }
                }
                if(leftChild.Count!=0&&rightChild.Count!=0)
                {
                    for(int k=0;k<leftChild.Count;k++)
                    {
                        for(int l=0;l<rightChild.Count;l++)
                        {
                            TreeNode root=new TreeNode(j);
                            root.left=Copy(leftChild[k]);
                            root.right=Copy(rightChild[l]);
                            item.Add(root);
                        }
                    }
                }
            }
            values.Add(item);
        }
        IList<TreeNode> last=values[n-1];
        foreach(var root in last)
        {
            InOrder(root,1);
        }
        return last;
    }
     private void InOrder(TreeNode root, int value)
      {
          if (root == null) return ;
          Stack<TreeNode> stack = new Stack<TreeNode>();
          GoAlongLeftBranch(root, stack);
          while (stack.Count != 0)
          {
              TreeNode node = stack.Peek();
              node.val = value;
              value++;
              stack.Pop();
              GoAlongLeftBranch(node.right, stack);
          }
      }
      private void GoAlongLeftBranch(TreeNode node, Stack<TreeNode> stack)
      {
          while (node != null)
          {
              stack.Push(node);
              node = node.left;
          }
      }
    private TreeNode Copy(TreeNode node)
    {
        if(node==null) return null;
        TreeNode newNode=new TreeNode(node.val);
        if(node.left!=null)
        {
            newNode.left=Copy(node.left);
        }
        if(node.right!=null)
        {
            newNode.right=Copy(node.right);
        }
        return newNode;
    }
    
}