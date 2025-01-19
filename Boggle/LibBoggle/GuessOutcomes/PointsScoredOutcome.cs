using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.GuessOutcomes
{
    internal class PointsScoredOutcome : GuessOutcome
    {
        public int Points = 0;

        public PointsScoredOutcome(string guess, int points) : base(guess)
        {
            Points = points;
        }

        public override string GetMessage()
        {
            return $"Well done! You found '{Guess}' (+{Points} pts).";
        }
    }
}
