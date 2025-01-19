using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    public class GridSearcher
    {
        public bool found = false;
        private HashSet<string> seen = new HashSet<string>();
        private string target;
        private string[,] grid;

        public int m;
        public int n;

        public GridSearcher(string word, string[,] boardstate)
        {
            target = word.ToUpper();
            grid = boardstate;

            m = grid.GetLength(0);
            n = grid.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Explore(i, j, 0);
                }
            }
        }

        private bool ValidCoordinates(int i, int j)
        {
            return (0 <= i && i < m) && (0 <= j && j < n);
        }

        private void Explore(int i, int j, int d)
        {
            if (d == target.Length)
            {
                found = true;
            }

            if (seen.Contains($"{i},{j}") || !ValidCoordinates(i, j) || found)
            {
                return;
            }

            string part = grid[i, j].ToUpper();

            if (d + part.Length > target.Length || target.Substring(d, part.Length) != part)
            {
                return;
            }

            d += part.Length;
            seen.Add($"{i},{j}");

            for (int a = i - 1; a <= i + 1; a++)
            {
                for (int b = j - 1; b <= j + 1; b++)
                {
                    Explore(a, b, d);
                }
            }

            seen.Remove($"{i},{j}");
        }

    }
}
