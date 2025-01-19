using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBoggle.GuessOutcomes
{
    internal class WordAlreadyFoundOutcome : GuessOutcome
    {
        public WordAlreadyFoundOutcome(string guess) : base(guess)
        {
        }

        public override string GetMessage()
        {
            return $"Sorry, you've already found '{Guess}'.";
        }
    }
}
