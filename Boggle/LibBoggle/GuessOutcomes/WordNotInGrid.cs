using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.GuessOutcomes
{
    internal class WordNotInGrid : GuessOutcome
    {
        public WordNotInGrid(string guess) : base(guess)
        {
        }

        public override string GetMessage()
        {
            return $"Sorry, '{Guess}' wasn't found in the grid.";
        }
    }
}
