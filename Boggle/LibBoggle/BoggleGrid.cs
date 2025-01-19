using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal class BoggleGrid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public string[,] Grid { get; private set; }

        private List<BoggleDie> Dice;

        public BoggleGrid(int rows, int columns, IDiceConfig diceConfig)
        {
            Rows = rows;
            Columns = columns;
            Dice = diceConfig.GetDice(rows * columns);
            Grid = new string[Rows,Columns];
            UpdateGrid();
        }

        public void Randomize(Randomizer randomizer)
        {
            randomizer.ShuffleDice(Dice);
            foreach(BoggleDie die in Dice)
            {
                die.Roll(randomizer);
            }
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            int p = 0;
            for(int i=0; i < Rows; i++)
            {
                for(int j=0; j<Columns; j++)
                {
                    BoggleDie die = Dice[p++];
                    Grid[i, j] = die.Face;
                }
            }
        }
    }
}
