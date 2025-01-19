using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.GuessOutcomes
{
    internal class WordTooShort : GuessOutcome
    {
        public WordTooShort(string guess) : base(guess)
        {

        }

        public override string GetMessage()
        {
            return $"Sorry, '{Guess}' is too short! Guesses must be at least 3 letters long.";
        }
    }
}
