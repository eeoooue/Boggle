using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL_Library
{
    public class BoggleGrid
    {
        private static BoggleGrid? _instance;

        public string[,] grid;

        private Dice[] dice;
        private int m;
        private int n;
        private BoggleGrid(int rows = 4, int columns=4, int d=16)
        {
            m = rows;
            n = columns;
            grid = new string[m, n];
            dice = new Dice[d];

            LoadDice(d);
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            ShuffleDice();
            UpdateGrid();
        }

        public static BoggleGrid GetInstance(int m=4, int n=4, int d=16)
        {
            if(_instance == null)
            {
                _instance = new BoggleGrid(m, n, d);
            }

            return _instance;
        }

        private void LoadDice(int d)
        {
            string[] diceMaps = {
                "A,A,E,E,G,N",
                "A,B,B,J,O,O",
                "A,C,H,O,P,S",
                "A,F,F,K,P,S",
                "A,O,O,T,T,W",
                "C,I,M,O,T,U",
                "D,E,I,L,R,X",
                "D,E,L,R,V,Y",
                "D,I,S,T,T,Y",
                "E,E,G,H,N,W",
                "E,E,I,N,S,U",
                "E,H,R,T,V,W",
                "E,I,O,S,S,T",
                "E,L,R,T,T,Y",
                "H,I,M,N,U,Qu",
                "H,L,N,N,R,Z"
            };

            int n = diceMaps.Length;

            for(int i=0; i<d; i++)
            {
                dice[i] = new Dice(diceMaps[i % n]);
            }
        }

        private void UpdateGrid()
        {
            int d = dice.Length;
            int p = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = dice[p++].GetCurrentFace();
                    if (p == d)
                    {
                        return;
                    }
                }
            }
        }

        private void ShuffleDice()
        {
            dice = ReorderedDice();

            foreach (Dice die in dice)
            {
                die.RollDie();
            }
        }

        private Dice[] ReorderedDice()
        {
            int d = dice.Length;

            HashSet<int> seen = new HashSet<int>();
            Random randomizer = new Random();
            Dice[] result = new Dice[d];

            int p = 0;
            while (p < d)
            {
                int i = randomizer.Next(d);
                if (!seen.Contains(i))
                {
                    seen.Add(i);
                    result[p++] = dice[i];
                }
            }

            return result;
        }
    }
}
