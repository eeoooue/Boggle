using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle
{
    internal class Randomizer
    {
        private Random Random = new Random();

        public int PickRandomIndex(int count)
        {
            return Random.Next(0, count);
        }

        public void ShuffleDice(List<BoggleDie> dice)
        {
            int n = dice.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = PickRandomIndex(i + 1);
                (dice[i], dice[j]) = (dice[j], dice[i]);
            }
        }
    }
}
