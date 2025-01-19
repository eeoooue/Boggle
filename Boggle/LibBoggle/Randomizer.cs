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

        public int RollD6()
        {
            return 1 + Random.Next(0, 6);
        }

        public int PickRandomIndex(int count)
        {
            return Random.Next(0, count);
        }

        public List<BoggleDie> ShuffleDice(List<BoggleDie> dice)
        {
            List<BoggleDie> result = new List<BoggleDie>();
            HashSet<int> seen = new HashSet<int>();

            while (result.Count < dice.Count)
            {
                int i = PickRandomIndex(dice.Count);

                if (!seen.Contains(i))
                {
                    seen.Add(i);
                    result.Add(dice[i]);
                }
            }

            return dice;
        }
    }
}
