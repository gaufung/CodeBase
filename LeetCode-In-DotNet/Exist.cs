public class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            if (String.IsNullOrEmpty(word)) return true;
            bool[,] vistited = new bool[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (word[0] == board[i, j])
                    {
                        IList<bool> res = new List<bool>();
                        vistited[i, j] = true;
                        Exist(board, i, j, 0, word, res, vistited);
                        if (res.Count > 0)
                            return true;
                        Reset(vistited);
                    }
                }
            }
            return false;
        }
        private void Reset(bool[,] vistied)
        {
            for (int i = 0; i < vistied.GetLength(0); i++)
            {
                for (int j = 0; j < vistied.GetLength(1); j++)
                    vistied[i, j] = false;
            }
        }
        private void Exist(char[,] board, int row, int column, int k, string word, IList<bool> res, bool[,] visited)
        {
            if (k == word.Length - 1)
            {
                res.Add(true);
                return;
            }
            if (k >= word.Length) return;
            if (column - 1 >= 0 && k < word.Length - 1 && board[row, column - 1] == word[k + 1] && !visited[row, column - 1])
            {
                if (res.Count == 0)
                {
                    visited[row, column - 1] = true;
                    Exist(board, row, column - 1, ++k, word, res, visited);
                    k--;
                    visited[row, column - 1] = false;
                }

            }
            if (row - 1 >= 0 && k < word.Length - 1 && board[row - 1, column] == word[k + 1] && !visited[row - 1, column])
            {
                if (res.Count == 0)
                {
                    visited[row - 1, column] = true;
                    Exist(board, row - 1, column, ++k, word, res, visited);
                    k--;
                    visited[row - 1, column] = false;
                }

            }
            if (column + 1 < board.GetLength(1) && k < word.Length - 1 && board[row, column + 1] == word[k + 1] && !visited[row, column + 1])
            {
                if (res.Count == 0)
                {
                    visited[row, column + 1] = true;
                    Exist(board, row, column + 1, ++k, word, res, visited);
                    k--;
                    visited[row, column + 1] = false;
                }

            }
            if (row + 1 < board.GetLength(0) && k < word.Length - 1 && board[row + 1, column] == word[k + 1] && !visited[row + 1, column])
            {
                if (res.Count == 0)
                {
                    visited[row + 1, column] = true;
                    Exist(board, row + 1, column, ++k, word, res, visited);
                    --k;
                    visited[row + 1, column] = false;
                }
            }
        }
    }