 public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            IList<int> res = new List<int>();
            int left = 0;
            int right = 0;
            int bottom = 0;
            int top = 0;
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            while (true)
            {
                if (left + right >= width && bottom + top >= height)
                    break;
                if (top + bottom < height)
                {
                    //top行
                    for (int i = left; i < width - right; i++)
                        res.Add(matrix[top, i]);
                    top++;
                }
                if (right+left<width)
                {
                    //right 列
                    for (int j = top; j < height - bottom; j++)
                        res.Add(matrix[j, width - right - 1]);
                    right++;
                }
                if (top + bottom < height)
                {
                    //bottom 行
                    for (int k = width - right - 1; k >= left; k--)
                        res.Add(matrix[height - bottom - 1, k]);
                    bottom++;
                }
                if (right + left < width)
                {
                    //left列
                    for (int l = height - bottom - 1; l >= top; l--)
                        res.Add(matrix[l, left]);
                    left++;
                }
               
            }
            return res;
        }
    }